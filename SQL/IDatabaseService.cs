using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQL
{
	public interface IDatabaseService
	{
		/// <summary>
		///  Executes a Transact-SQL stored procedure against the database and returns the number of rows affected. 
		/// </summary>
		/// <param name="sqlProc">Stored procedure to execute</param>
		/// <param name="parameters">Array of SqlParameters to use for the procedure. If this is <strong>null</strong> then no parameters are passed.</param>
		/// <returns>Returns the number of rows affected.</returns>
		int ExecuteNonQuery(string sqlProc, SqlParameter[] parameters);

		/// <summary>
		/// Executes a Transact-SQL stored procedure against the database and returns an object representing the result.
		/// </summary>
		/// <param name="sqlProc">Stored procedure to execute</param>
		/// <param name="parameters">Array of SqlParameters to use for the procedure. If this is <strong>null</strong> then no parameters are passed.</param>
		/// <returns>Returns an object representing the output of the stored procedure.</returns>
		object ExecuteScalar(string sqlProc, SqlParameter[] parameters);

		/// <summary>
		/// Executes a Transact-SQL stored procedure against the database and returns a <see cref="SqlDataReader"/> representing the result.
		/// </summary>
		/// <param name="sqlProc">Stored procedure to execute</param>
		/// <param name="parameters">Array of SqlParameters to use for the procedure. If this is <strong>null</strong> then no parameters are passed.</param>
		/// <returns>Returns a <see cref="SqlDataReader"/> representing the result. The returned <see cref="SqlDataReader"/> uses the 
		SqlDataReader ExecuteReader(string sqlProc, SqlParameter[] parameters);

		///// Executes a Transact-SQL stored procedure against the database and returns a <see cref="DataSet"/> representing the result.
		///// </summary>
		///// <param name="sqlProc">Stored procedure to execute</param>
		///// <param name="parameters">Array of SqlParameters to use for the procedure. If this is <strong>null</strong> then no parameters are passed.</param>
		///// <returns>Returns a <see cref="DataSet"/> representing the result. The returned <see cref="DataSet"/> uses the 
		//DataSet ExecuteDataSet(string sqlProc, SqlParameter[] parameters);

		///// <summary>
		///// Closes the database connection.
		///// </summary>
		//void Close();

	}
}
