using DesignMaterialsStore.DAO.implement;
using DesignMaterialsStore.Model;
using DesignMaterialsStore.Singleton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DesignMaterialsStore.DAO
{
    public class DAOFactory
    {

        //Fields
        protected static MySqlConnection conn = DBconnection.getInstance(); 

        //Methods

        /// <summary>
        /// return a client object interacting with the database
        /// </summary>
        /// <returns>ClientDAO</returns>
        public static ClientDAO getClientDAO()
        {
            return new ClientDAO(conn);
        }

        /// <summary>
        /// return a Invoice object interacting with the database
        /// </summary>
        /// <returns>InvoiceDAO</returns>
        public static InvoiceDAO getInvoiceDAO()
        {
            return new InvoiceDAO(conn);
        }

        /// <summary>
        /// return a Item object interacting with the database
        /// </summary>
        /// <returns>ItemDAO</returns>
        public static ItemDAO getItemDAO()
        {
            return new ItemDAO(conn);
        }

        /// <summary>
        /// return a Invoice object interacting with the database
        /// </summary>
        /// <returns>InvoiceItemDAO</returns>
        public static InvoiceItemDAO getInvoiceItemDAO()
        {
            return new InvoiceItemDAO(conn);
        }

        /// <summary>
        /// return a Worker object interacting with the database
        /// </summary>
        /// <returns>WorkerDAO</returns>
        public static WorkerDAO getWorkerDAO()
        {
            return new WorkerDAO(conn);
        }
    }//end class
}//end namespace
