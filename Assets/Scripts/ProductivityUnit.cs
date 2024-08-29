using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ProductivityUnit : Unit
    {
        public ResourcePile m_Currentpile = null;
        public float productionMultiplier= 2;

        protected override void BuildingInRange()
        {
            if(m_Currentpile == null)
            {
                ResourcePile pile = m_Target as ResourcePile;
                if(pile != null)
                {
                    m_Currentpile = pile;
                    m_Currentpile.ProductionSpeed *=  productionMultiplier;
                    Debug.Log("production is doubled");
                }
            }
          
           
        }
        // it should be called when a productiviy Unty leaves the ResourcePile
        public void ResetProductivity()
        {
            if (m_Currentpile != null)
            {
                m_Currentpile.ProductionSpeed /= productionMultiplier;
                m_Currentpile = null;
            } 
        }
        public override void GoTo(Building target)
        {
            ResetProductivity();
            base.GoTo(target);

        }
        public override void GoTo(Vector3 position)
        {
            ResetProductivity();
            base.GoTo(position);
        }
        public override string GetName()
        {
            return "Productivity Unit";
        }
    }
}