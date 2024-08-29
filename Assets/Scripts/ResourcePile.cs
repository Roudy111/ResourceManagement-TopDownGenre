using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using UnityEngine;

/// <summary>
/// A subclass of Building that produce resource at a constant rate.
/// </summary>
public class ResourcePile : Building
{
    public ResourceItem Item;
    private float m_ProdcutionSpeed = 0.5f;
    public float ProductionSpeed 
    {
        get { return m_ProdcutionSpeed;}
        set 
        {   if(value<0.0f)
                {
                    Debug.LogError("You Cannot set the Value Negetive");
                }
            else
                {
                    value = m_ProdcutionSpeed;
                }    

        }
        
           

        

    }


    private float m_CurrentProduction = 0.0f;

    private void Update()
    {
        if (m_CurrentProduction > 1.0f)
        {
            int amountToAdd = Mathf.FloorToInt(m_CurrentProduction);
            int leftOver = AddItem(Item.Id, amountToAdd);

            m_CurrentProduction = m_CurrentProduction - amountToAdd + leftOver;
        }
        
        if (m_CurrentProduction < 1.0f)
        {
            m_CurrentProduction += m_ProdcutionSpeed * Time.deltaTime;
        }
    }

    public override string GetData()
    {
        return $"Producing at the speed of {m_ProdcutionSpeed}/s";
        
    }
    
    
}
