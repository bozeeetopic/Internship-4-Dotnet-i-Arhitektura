using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Domain.GetAndSet
{
    public class SetFunctions
    {
        public static void AddUser(string name, string surname, string adress, int distance)
        {
            var user = new Data.Entities.User();
            user.Populate(name,surname,adress,distance);
            Data.Seed.CurrentUser.Populate(name, surname, adress, distance);
            if (Data.Seed.Users == null)
            {
                Data.Seed.Users.Add(user);
            }
            if (!Data.Seed.Users.Contains(user))
            {
                Data.Seed.Users.Add(user);
            }
        }
        public static int AddProcessor(int userChoice, List<Data.Entities.Processor> processors)
        {
            if(Seed.Computer.Processor==null)
            {
                Seed.Computer.Processor = processors[userChoice];
                return 8;
            }
            Seed.Computer.Processor = processors[userChoice];
            return 0;
        }
        public static int AddRAM(int userChoice, List<Data.Entities.RAM> rams, int ramAmount)
        {
            if (Seed.Computer.RAM == null)
            {
                Seed.Computer.RAMAmount = ramAmount;
                Seed.Computer.RAM = rams[userChoice];
                return 4;
            }
            Seed.Computer.RAMAmount = ramAmount;
            Seed.Computer.RAM = rams[userChoice];
            return 0;
        }
        public static int AddHardDisk(int userChoice, List<Data.Entities.HardDisk> hardDiscs)
        {
            if (Seed.Computer.HardDisk == null)
            {
                Seed.Computer.HardDisk = hardDiscs[userChoice];
                return 2;
            }
            Seed.Computer.HardDisk = hardDiscs[userChoice];
            return 0;
        }
        public static int AddCase(int userChoice, List<Data.Entities.Case> cases)
        {
            if (Seed.Computer.ComputerCase == null)
            {
                Seed.Computer.ComputerCase = cases[userChoice];
                return 1;
            }
            Seed.Computer.ComputerCase = cases[userChoice];
            return 0;
        }
    }
}
