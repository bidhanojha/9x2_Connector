using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Data.SqlClient;


namespace ClassMathCustomActivity
{
    public class StateInfoToDB : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<double> StateNumber { get; set; }

        [Category("Input")]
        public InArgument<string> StateName { get; set; }

        [Category("Output")]
        public OutArgument<Boolean> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var stateNumb = StateNumber.Get(context);
            var stateName = StateName.Get(context);
            //var result = System.Math.Pow(firstNumber + secondNumber, 2);

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-ENFECBU\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;User Instance=True");

            string sql = "insert into NewTable (Name, Age) values (stateName, 100)";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                Result.Set(context, true);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                Result.Set(context, false);
            }
            finally
            {
                conn.Close();
            }
                                                     
        }
    }
}