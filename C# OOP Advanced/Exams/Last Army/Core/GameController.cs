using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;


    public class GameController : IGameController
    {
        private const string CommandSuffix = "Command";
        private Type[] commands;

        public GameController(IArmy army, IWareHouse wareHouse, 
            MissionController missionControllerField,
            IAmmunitionFactory ammunitionFactory,
            ISoldierFactory soldierFactory,
            IMissionFactory missionFactory)
        {
            this.Army = army;
            this.WareHouse = wareHouse;
            this.MissionControllerProp = missionControllerField;
            this.AmmunitionFactory = ammunitionFactory;
            this.SoldierFactory = soldierFactory;
            this.MissionFactory = missionFactory;
            this.commands = new TypeCollector().GetAllInheritingTypes<ICommand>();
        }

        public IArmy Army { get; private set; }

        public IWareHouse WareHouse { get; }
        public MissionController MissionControllerProp { get; }
        public IAmmunitionFactory AmmunitionFactory { get; }
        public ISoldierFactory SoldierFactory { get; }
        public IMissionFactory MissionFactory { get; }

        public void GiveInputToGameController(string input)
        {
            var data = input.Split();

            var commandName = data[0];
            if (commandName.Equals("Soldier", StringComparison.OrdinalIgnoreCase) &&
                (data[1].Equals("Regenerate", StringComparison.OrdinalIgnoreCase)))
            {
                commandName = "SoldierRegenerate";
                data = data.Skip(2).ToArray();
            }
            else
            {
                data = data.Skip(1).ToArray();
            }

            commandName += CommandSuffix;
            var commandType = this.commands
                .FirstOrDefault(c => c.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));

            var commandInstance = (ICommand) Activator.CreateInstance(commandType, data, this); !!! this да се използва ЗАДЪЛЖИТЕЛНО!!!!
            commandInstance.Execute();

        }

        public void RegenerateSoldiers(string soldiersType) => this.Army.RegenerateTeam(soldiersType);

        public override string ToString()
        {
            this.MissionControllerProp.FailMissionsOnHold();

            var sb = new StringBuilder();
            sb.AppendLine("Results:")
                .AppendLine($"Successful missions - {this.MissionControllerProp.SuccessMissionCounter}")
                .AppendLine($"Failed missions - {this.MissionControllerProp.FailedMissionCounter}")
                .AppendLine("Soldiers:");

            foreach (var solider in this.Army.Soldiers.OrderByDescending
                (s => s.OverallSkill))
            {
                sb.AppendLine(solider.ToString());
            }

            return sb.ToString().Trim();
        }
    }
