using System;
using System.Linq;
using System.Collections.Generic;

public static class SoldierFactory
{
    private static Soldier GetSoldier(string[] soldierParams)
    {
        string id = soldierParams[0];
        string firstName = soldierParams[1];
        string lastName = soldierParams[2];

        return new Soldier(id, firstName, lastName);
    }

    private static Private GetPrivate(string[] privateParams)
    {
        Soldier soldier = GetSoldier(privateParams);

        decimal salary = decimal.Parse(privateParams[3]);

        return new Private(soldier, salary);
    }

    private static SpecializedSoldier GetSpecializedSoldier(string[] specSoldierParams)
    {
        if (!Enum.TryParse(specSoldierParams[4], out Enums.Corps corps))
        {
            return null;
        }

        Private privateObj = GetPrivate(specSoldierParams);

        return new SpecializedSoldier(privateObj, corps);
    }

    private static LeutenantGeneral GetLeutenantGeneral(string[] leutenantGeneralParams, Dictionary<string, Private> privatesById)
    {
        Private privateObj = GetPrivate(leutenantGeneralParams);

        List<Private> privates = new List<Private>();

        foreach (string privateId in leutenantGeneralParams.Skip(4))
        {
            privates.Add(privatesById[privateId]);
        }

        return new LeutenantGeneral(privateObj, privates);
    }    

    private static Engineer GetEngineer(string[] engineerParams)
    {
        SpecializedSoldier specSoldier = GetSpecializedSoldier(engineerParams);

        if (specSoldier == null)
        {
            return null;
        }

        List<Repair> repairs = new List<Repair>();

        for (int i = 5; i < engineerParams.Length; i += 2)
        {
            string repairPart = engineerParams[i];
            int repairHours = int.Parse(engineerParams[i + 1]);

            Repair repair = new Repair(repairPart, repairHours);

            repairs.Add(repair);
        }

        return new Engineer(specSoldier, repairs);
    }

    private static Commando GetCommando(string[] commandoParams)
    {
        SpecializedSoldier specSoldier = GetSpecializedSoldier(commandoParams);

        if (specSoldier == null)
        {
            return null;
        }

        List<Mission> missions = new List<Mission>();

        for (int i = 5; i < commandoParams.Length; i += 2)
        {
            string missionCodeName = commandoParams[i];

            if (!Enum.TryParse(commandoParams[i + 1], out Enums.MissionState missionState))
            {
                continue;
            }

            Mission mission = new Mission(missionCodeName, missionState);

            missions.Add(mission);
        }

        return new Commando(specSoldier, missions);
    }

    private static Spy GetSpy(string[] spyParams)
    {
        Soldier soldier = GetSoldier(spyParams);

        int codeNumber = int.Parse(spyParams[3]);

        return new Spy(soldier, codeNumber);
    }

    public static ISoldier GetSoldier(Enums.SoldierType soldierType, string[] soldierParams, Dictionary<string, Private> privatesById)
    {
        ISoldier soldier = null;

        switch (soldierType)
        {
            case Enums.SoldierType.Private:
                soldier = GetPrivate(soldierParams);
                privatesById[soldier.Id] = (Private)soldier;
                break;
            case Enums.SoldierType.LeutenantGeneral:
                soldier = GetLeutenantGeneral(soldierParams, privatesById);
                break;
            case Enums.SoldierType.Engineer:
                soldier = GetEngineer(soldierParams);
                break;
            case Enums.SoldierType.Commando:
                soldier = GetCommando(soldierParams);
                break;
            case Enums.SoldierType.Spy:
                soldier = GetSpy(soldierParams);
                break;
        }

        return soldier;
    }
}