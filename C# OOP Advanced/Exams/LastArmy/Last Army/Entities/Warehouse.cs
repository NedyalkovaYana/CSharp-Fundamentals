using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Warehouse : IWareHouse
{
    private IDictionary<string, int> weapons;
    private IAmmunitionFactory ammunitionFactory;

    public Warehouse()
    : this(new Dictionary<string, int>(), new AmmunitionFactory())
    {
        
    }
    public Warehouse(IDictionary<string, int> weapons, IAmmunitionFactory ammunitionFactory)
    {
        this.weapons = weapons;
        this.ammunitionFactory = ammunitionFactory;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public void AddAmmunitions(string name, int count)
    {
        if (!weapons.ContainsKey(name))
        {
            this.weapons.Add(name, 0);
        }

        this.weapons[name] += count;
    }

    public bool TryEquipSoldier(ISoldier sildier)
    {
        bool isEqipted = true;

        List<string> missingWeapons = sildier.Weapons
            .Where(w => w.Value == null)
            .Select(w => w.Key).ToList();

        foreach (var weaponName in missingWeapons)
        {
            if (this.weapons.ContainsKey(weaponName) && this.weapons[weaponName] > 0)
            {
                sildier.Weapons[weaponName] = this.ammunitionFactory.CreateAmmunition(weaponName);
                this.weapons[weaponName]--;
            }
            else
            {
                isEqipted = false;
            }
        }

        return isEqipted;
    }
}

