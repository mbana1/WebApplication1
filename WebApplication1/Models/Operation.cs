using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
  public  class Operation
    {
        public float OperandeGauche { get; private set; }
        public string Operateur { get; private set; }
        public float OperandeDroite { get; private set; }

        public Operation(float operandeGauche, string operateur, float operandeDroite)
        {
            this.OperandeGauche = operandeGauche;
            this.Operateur = operateur;
            this.OperandeDroite = operandeDroite;
        }

        public float GetResultat()
        {
            switch (Operateur)
            {
                case "+":
                    return OperandeGauche + OperandeDroite;
                case "-":
                    return OperandeGauche - OperandeDroite;
                case "*":
                    return OperandeGauche * OperandeDroite;
                case "/":
                    return OperandeGauche / OperandeDroite;
                case "^":
                    return (float)Math.Pow(OperandeGauche, OperandeDroite);
            }
            throw new Exception("Opérateur non reconnu");
        }

        public bool IsValide()
        {
            switch (Operateur)
            {
                case "/":
                    return OperandeDroite != 0.0f;
                case "^":
                    return OperandeDroite >= 0.0f;
                default:
                    return true;
            }
        }
    }
}