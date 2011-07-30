/*	 
	Copyright 2007 Mark S. Rasmussen - www.improve.dk

    This file is part of Multi Table Helper.

    Multi Table Helper is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Multi Table Helper is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MTH.Framework
{
	public interface IPokerTable
	{
		string SiteName { get; }
		string OwnerProcessExe { get; }
		string TableName { get; }
		int WindowHandle { get; }
		string WindowTitle { get; }
		string WindowClassName { get; }
		int WindowHeight { get; }
		int WindowWidth { get; }
		ICore Core { get; set; }
		void BringToFront();
		void HideBorder();
		void InvalidateDrawings();
		void ShowBorder(Color color);
		void ForceRedraw();
		void MoveToQuadrant(Quadrant quad, bool activeQuad);
		Point WindowPosition { get; }
		void SetSize(Size size);
		void UpdateChildren();
		void InvokeActionTick();
		Rectangle WindowRectangle { get; }
		bool IsActiveTable { get; }
		double GetAspectRatio(int width);
		void Die();
		void CloseWindow();
		void MoveCursorToTable();
		void AutoPush();
		bool IsSeated { get; }
		string GetRaiseValue();
		void CheckCall();
		void Fold();
		void BetRaise();
		bool NeedsAction { get; }
		void SetRaiseValue(string raiseValue);
		void MoveToLastLocation();
		bool IsSittingOut { get; }
		int Quadrant { get; set; }
		IPokerTable Create(int handle);
		bool IsPokerTable(int handle);
		bool IsResizable { get; }
		Size MinTableSize { get; }
		DateTime LastRequiredAction {get; }
		Size MaxTableSize { get; }
		event Delegates.ClosedEventHandler Closed;
		event Delegates.RequiresActionEventHandler RequiresAction;
		event Delegates.NoLongerRequiresActionEventHandler NoLongerRequiresAction;
		event Delegates.SittingOutEventHandler SittingOut;
		event Delegates.SittingInEventHandler SittingIn;
		event Delegates.SeatedEventHandler Seated;
		event Delegates.UnSeatedEventHandler UnSeated;
	}
}