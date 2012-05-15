using System;
using NKH.MindSqualls.MotorControl;

namespace SortAlgoBot.Commands
{
    public interface IRobotCommand
    {
        string Name { get; }
        void Execute(McNxtBrick brick);
    }

    public class RobotForwardToEndFromHomeCommand : IRobotCommand
    {
        //#region IRobotCommand Members

        //public string Name
        //{
        //    get { return "RobotForwardToEndFromHomeCommand"; }
        //}

        //public void Execute(McNxtBrick brick)
        //{
        //    var sortRail = new SortRailList();
        //    int resultTacho = 0;
        //    if (!brick.IsMotorControlRunning())
        //        brick.StartMotorControl();

        //    resultTacho = MotorHelper.RunAndWait(
        //        brick,
        //        sortRail.GetTachoForPosition(3, 0),
        //        MotorDirection.Forward);

        //    resultTacho = MotorHelper.RunAndWait(
        //        brick,
        //        sortRail.GetTachoForPosition(12, resultTacho),
        //        MotorDirection.Forward);

        //    MotorHelper.RunAndWait(
        //        brick,
        //        sortRail.GetTachoForPosition(5, resultTacho),
        //        MotorDirection.Backward);

        //    MotorHelper.RunAndWait(
        //        brick,
        //        sortRail.GetTachoForPosition(0, resultTacho),
        //        MotorDirection.Backward);
        //}

        //#endregion

        // 20+20+5 = 46 lego posities in 45 stappen dus delen door 45
        // 1 home posities = 8 lego posities
        // 1 lego positie is 110 tacho
        // total tacho 4950

        #region IRobotCommand Members

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public void Execute(McNxtBrick brick)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}