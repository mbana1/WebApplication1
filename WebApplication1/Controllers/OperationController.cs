using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;


namespace WebApplication1.Controllers
{
    public class OperationController : Controller
    {
        // GET: Operation
        public ActionResult Addition(float operandeGauche, float operandeDroite)
        {
            
            Operation operationtest = new Operation(operandeGauche,"+", operandeDroite);
           
            EnregistrerOperation(operandeGauche, "+", operandeDroite);


            return View(operationtest);
        }



        public string Soustraction(float operandeGauche, float operandeDroite)
        {

            Operation operationtest = new Operation(operandeGauche, "-", operandeDroite);

            EnregistrerOperation(operandeGauche, "-", operandeDroite);


            return "le résultat de l'oppération est  :" + operationtest.GetResultat() ;
        }
        public string Multiplication(float operandeGauche, float operandeDroite)
        {

            Operation operationtest = new Operation(operandeGauche, "*", operandeDroite);

            EnregistrerOperation(operandeGauche, "*", operandeDroite);


            return "le résultat de l'oppération est  :" + operationtest.GetResultat();
        }
        public string Division(float operandeGauche, float operandeDroite)
        {

            Operation operationtest = new Operation(operandeGauche, "/", operandeDroite);

            EnregistrerOperation(operandeGauche, "/", operandeDroite);


            return "le résultat de l'oppération est  :" + operationtest.GetResultat();
        }
        public string Exposant(float operandeGauche, float operandeDroite)
        {

            Operation operationtest = new Operation(operandeGauche, "^", operandeDroite);

            EnregistrerOperation(operandeGauche, "^", operandeDroite);


            return "le résultat de l'oppération est  :" + operationtest.GetResultat();
        }
        const string cheminBase = @"Server=.\sqlexpress;Initial Catalog = Calculatrice; Integrated Security = True";
        public static void EnregistrerOperation(double operandedeGauche, string operateur, double operandedroite)
        {
            SqlConnection connection = new SqlConnection(cheminBase);



            connection.Open();

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "INSERT INTO Operation(OperandeGauche,Operateur, OperandeDroite) VALUES (@operandedeGauche,@operateur,@operandedroite)";
            command.Parameters.AddWithValue("@operandedeGauche", operandedeGauche);
            command.Parameters.AddWithValue("@operateur", operateur);
            command.Parameters.AddWithValue("@operandedroite", operandedroite);

            command.ExecuteNonQuery();
            connection.Close();
            command.Parameters.Clear();
        }
        public string NombreOperation()
        {
            SqlConnection connection = new SqlConnection(cheminBase);



            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Operation", connection);
            int NombreOperation = (int)command.ExecuteScalar();

            //command.ExecuteNonQuery();
            connection.Close();
            command.Parameters.Clear();
            return "Vous avez effectuer : " + NombreOperation + "  opérations";

        }

        public static void CalculeRealiser()
        {
            SqlConnection connection = new SqlConnection(cheminBase);



            connection.Open();

            SqlCommand command = new SqlCommand("SELECT OperandeGauche,Operateur,OperandeDroite FROM Operation", connection);
            SqlDataReader datareader = command.ExecuteReader();
            List<Operation> ListeDesOperations = new List<Operation>();
            while (datareader.Read())
            {
                Operation OperationsEfectuee = new Operation(datareader.GetFloat(0), datareader.GetString(1), datareader.GetFloat(2));
                

                ListeDesOperations.Add(OperationsEfectuee);

                /*Console.WriteLine("vous avez effectué les opérations suivante  :" + PGauche + "  " + Poperation + "  " + Pdroite); Console.WriteLine("\n")*/
                ;

            }
            foreach (Operation operations in ListeDesOperations)
            {


               




            }
            //command.ExecuteNonQuery();
            connection.Close();
            command.Parameters.Clear();


        }
    }
}