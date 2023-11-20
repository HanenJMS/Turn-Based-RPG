using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPGSandBox.RelationshipSystem.Faction
{
    public interface IHaveAFaction
    {

    }
    public class FactionSystem : MonoBehaviour
    {
        List<Faction> factions;


    }

    [System.Serializable]
    public class Faction : IHaveAFaction
    {
        //List<IAmAUnit>() members;

        //bool AddMember(IAmAUnit);

        //bool RemoveMember(IAmAUnit);


    }
}

