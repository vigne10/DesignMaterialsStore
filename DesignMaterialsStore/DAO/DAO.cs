using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMaterialsStore.DAO
{
    /// <summary>
    /// abstract class that defines everything that the DAO classes of the different objects must contain
    /// </summary>
    /// <typeparam name="T">DAO object (for example : Client)</typeparam>
    public abstract class DAO<T>
    {

        //Fields
        protected MySqlConnection conn; //connection to MySQL

        //Constructor
        public DAO(MySqlConnection conn)
        {
            this.conn = conn; //set the connection field
        }

        //Methods
        public abstract bool create(T obj); //method to create a T object

        public abstract bool update(T obj); //method to update a T object

        public abstract bool delete(T obj); //method to delete a T object

        public abstract ObservableCollection<T> findAll(); //method to find all the T objects

    }//end class
}//end namespace
