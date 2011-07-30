using System;
using System.Collections.Generic;
using System.Text;
using SpeechLib;
using System.Collections;

namespace MTH
{
    /// <summary>
    /// A class used for speech recognition
    /// </summary>
    class VoiceListener
    {
        // Voice vars
        private SpSharedRecoContext recoContext = null;
        private ISpeechRecoGrammar recoGrammar = null;
        private ISpeechGrammarRule recoGrammarRule = null;

        // An arraylist containing all possible commands
        private ArrayList commands = new ArrayList();

        /// <summary>
        /// Accessor
        /// </summary>
        public ArrayList Commands
        {
            get { return commands; }
            set { commands = value; }
        }

        // Events
        public delegate void CommandReceivedEventHandler(string CommandText);
        public event CommandReceivedEventHandler CommandReceived;
        
        /// <summary>
        /// Destructor, stops the listening
        /// </summary>
		~VoiceListener() 
		{
			Stop();
		}

        /// <summary>
        /// Adds a command
        /// </summary>
        /// <param name="cmd"></param>
        public void AddCommand(string cmd)
        {
            if (!commands.Contains(cmd))
                commands.Add(cmd);
        }

        /// <summary>
        /// Removes a command
        /// </summary>
        /// <param name="cmd"></param>
        public void RemoveCommand(string cmd)
        {
            commands.Remove(cmd);
        }

        /// <summary>
        /// Starts the listening
        /// </summary>
        public void Start()
        {
            recoContext = new SpSharedRecoContextClass();
            recoContext.Recognition += new _ISpeechRecoContextEvents_RecognitionEventHandler(recoContext_Recognition);

            recoGrammar = recoContext.CreateGrammar(0);
            recoGrammarRule = recoGrammar.Rules.Add("VoiceCommands", SpeechRuleAttributes.SRATopLevel | SpeechRuleAttributes.SRADynamic, 1);

            object propValue = "";

            for (int i = 0; i < commands.Count; i++)
                recoGrammarRule.InitialState.AddWordTransition(null, commands[i].ToString(), " ", SpeechGrammarWordType.SGLexical, Commands[i].ToString(), i, ref propValue, 1.0F);

            recoGrammar.Rules.Commit();
            recoGrammar.CmdSetRuleState("VoiceCommands", SpeechRuleState.SGDSActive);
        }

        /// <summary>
        /// Fires when a voice command has been received
        /// </summary>
        /// <param name="StreamNumber"></param>
        /// <param name="StreamPosition"></param>
        /// <param name="RecognitionType"></param>
        /// <param name="Result"></param>
        private void recoContext_Recognition(int StreamNumber, object StreamPosition, SpeechRecognitionType RecognitionType, ISpeechRecoResult Result)
        {
            // Fire the CommandReceived event with the received command text
            CommandReceived(Result.PhraseInfo.GetText(0, -1, false));
        }

        /// <summary>
        /// Speaks the provided text out load
        /// </summary>
        /// <param name="text"></param>
        public void Speak(string text)
        {
            SpVoice voice = new SpVoice();

            voice.Speak(text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        /// <summary>
        /// Restarts the listening, used for updating the rules
        /// </summary>
        public void Restart()
        {
            Stop();
            Start();
        }

        /// <summary>
        /// Stops the listening
        /// </summary>
        public void Stop()
        {
            recoContext = null;
            recoGrammar = null;
            recoGrammarRule = null;
        }
    }
}
