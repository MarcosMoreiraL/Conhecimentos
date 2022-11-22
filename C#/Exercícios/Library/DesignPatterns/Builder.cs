using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DesignPatterns
{
    public interface IComputerBuilder
    {
        void SetMonitor();
        void SetMouse();
        void SetKeyboard();
        void SetTower();
        void SetPrinter();

        Computer GetComputer();
    }

    public class Computer
    {
        public string Monitor { get; set; }
        public string Mouse { get; set; }
        public string Keyboard { get; set; }
        public string Tower { get; set; }
        public string Printer { get; set; }
    }

    public class ComputerABuilder : IComputerBuilder
    {
        Computer computer = new Computer();

        public Computer GetComputer()
        {
            return computer;
        }

        public void SetKeyboard()
        {
            computer.Keyboard = "Standard";
        }

        public void SetMonitor()
        {
            computer.Monitor = "Single";
        }

        public void SetMouse()
        {
            computer.Mouse = "Regular";
        }

        public void SetPrinter()
        {
            computer.Printer = "HP Laserjet 5000";
        }

        public void SetTower()
        {
            computer.Tower = "16GB RAM";
        }
    }

    public class ComputerBBuilder : IComputerBuilder
    {
        Computer computer = new Computer();

        public Computer GetComputer()
        {
            return computer;
        }

        public void SetKeyboard()
        {
            computer.Keyboard = "Standard";
        }

        public void SetMonitor()
        {
            computer.Monitor = "Dual";
        }

        public void SetMouse()
        {
            computer.Mouse = "Gaming";
        }

        public void SetPrinter()
        {
            computer.Printer = "HP Laserjet 7000";
        }

        public void SetTower()
        {
            computer.Tower = "64GB RAM";
        }
    }

    public class ComputerCreator
    {
        private IComputerBuilder computerBuilder;

        public ComputerCreator(IComputerBuilder computerBuilder)
        {
            this.computerBuilder = computerBuilder;
        }

        public void CreateComputer()
        {
            computerBuilder.SetMonitor();
            computerBuilder.SetMouse();
            computerBuilder.SetKeyboard();
            computerBuilder.SetTower();
            computerBuilder.SetTower();
        }

        public Computer GetComputer()
        {
            return computerBuilder.GetComputer();
        }
    }

    public class Builder
    {
        public static void TestComputerBuilder()
        {
            ComputerCreator computerACreator = new ComputerCreator(new ComputerABuilder());
            computerACreator.CreateComputer();

            ComputerCreator computerBCreator = new ComputerCreator(new ComputerBBuilder());
            computerACreator.CreateComputer();
        }
    }
}
