using System.ComponentModel.DataAnnotations;

namespace WhatTheHellDidIRoll.Lib;

public class Roll
{
    public Roll(int roll1, int roll2) => 
        (TensDice, UnitsDice) = (roll1, roll2);

    [Required]
    [Range(1, 10, ErrorMessage = "White Dice value must be between 1 and 10.")]
    [Display(Name = "Black Dice")]
    public int TensDice {get;set;}
    
    [Required]
    [Range(1, 10, ErrorMessage = "Black Dice value must be between 1 and 10.")]
    [Display(Name = "White Dice")]
    public int UnitsDice {get;set;}

    public int GetRoll()
    {
        int finalRoll;
        if (UnitsDice == 10)
        {
            finalRoll = TensDice * UnitsDice;
        } 
        else if (TensDice == 10)
        {
            finalRoll = UnitsDice;
        }
        else 
        {
            int.TryParse($"{TensDice}{UnitsDice}", out finalRoll);
        }

        return finalRoll;
    }
}