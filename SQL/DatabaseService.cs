using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SQL
{
	public class DatabaseService : IDatabaseService
	{
		private SqlConnection sqlConn;
		private SqlTransaction sqlTransaction;

		public int ExecuteNonQuery(string sqlProc, SqlParameter[] parameters)
		{
			EnsureDatabaseIsOpen();

			// create a command using the procedure, the connection and the optional transaction
			SqlCommand sqlCommand = CreateCommand(sqlProc, parameters);

			// execute it
			return sqlCommand.ExecuteNonQuery();
		}

		public object ExecuteScalar(string sqlProc, SqlParameter[] parameters)
		{
			EnsureDatabaseIsOpen();

			// create a command using the procedure, the connection and the optional transaction
			SqlCommand sqlCommand = CreateCommand(sqlProc, parameters);

			// execute it
			return sqlCommand.ExecuteScalar();
		}

		public SqlDataReader ExecuteReader(string sqlProc, SqlParameter[] parameters)
		{
			EnsureDatabaseIsOpen();

			// create a command using the procedure, the connection and the optional transaction
			SqlCommand sqlCommand = CreateCommand(sqlProc, parameters);

			// execute it
			return sqlCommand.ExecuteReader();
		}

		private SqlCommand CreateCommand(string sqlProc, SqlParameter[] parameters)
		{
			// create a command using the procedure, the connestion and the optional transaction
			SqlCommand sqlCommand = new SqlCommand(sqlProc, sqlConn, sqlTransaction);

			// we only support Stored Procedures
			sqlCommand.CommandType = CommandType.StoredProcedure;

			if (parameters != null)
			{
				// set null strings to DBNull
				foreach (SqlParameter parameter in parameters.Where(p => p.SqlDbType == SqlDbType.NVarChar && p.Value == null))
				{
					parameter.Value = DBNull.Value;
				}

				// copy the parameters into the command
				sqlCommand.Parameters.AddRange(parameters);
			}

			return sqlCommand;
		}

		private void EnsureDatabaseIsOpen()
		{
			if (sqlConn == null)
			{
				OpenDatabase();
			}
		}

		private void OpenDatabase()
		{
			// this should only be called from EnsureDatabaseIsOpen
			sqlConn = new SqlConnection();
			sqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["JBW"].ConnectionString;
			try
			{
				sqlConn.Open();
			}
			catch (Exception ex)
			{

			}
		}

	}
}
