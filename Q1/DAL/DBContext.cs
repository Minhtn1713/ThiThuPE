using Q1.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1.DAL
{
    internal class DBContext : BaseDAL
    {
        private static DBContext instance = null;
        private static readonly object instanceLock = new object();
        private DBContext() { }
        public static DBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DBContext();
                    }
                    return instance;
                }
            }
        }

        public List<Employee> GetEmployees()
        {
            IDataReader reader = null;
            string query = "select e.*, d.Name from Employee e, Department d where e.Department = d.Id";
            List<Employee> employees = new List<Employee>();
            try
            {
                reader = dataProvider.GetDataReader(query, CommandType.Text, out connection);
                while (reader.Read())
                {
                    
                    employees.Add(new Employee
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Dob = reader.GetDateTime(2),
                        Sex = reader.GetString(3),
                        Position = reader.GetString(4),
                        Department = reader.GetInt32(5),
                        DepartmentName = reader.GetString(6)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                CloseConnection();
            }
            return employees;
        }

        public List<Employee> GetEmployeesByName(string name)
        {
            IDataReader reader = null;
            string query = "select e.*, d.Name from Employee e, Department d where e.Department = d.Id" +
                " and e.Name like '%" + name + "%'";
            List<Employee> employees = new List<Employee>();
            try
            {
                //var param = dataProvider.CreateParameter("@name", 30, name, DbType.String);
                reader = dataProvider.GetDataReader(query, CommandType.Text, out connection);
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Dob = reader.GetDateTime(2),
                        Sex = reader.GetString(3),
                        Position = reader.GetString(4),
                        Department = reader.GetInt32(5),
                        DepartmentName = reader.GetString(6)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                CloseConnection();
            }
            return employees;
        }

        public List<Employee> GetEmployeesByGender(string gen)
        {
            IDataReader reader = null;
            string query = "select e.*, d.Name from Employee e, Department d where e.Department = d.Id" +
                " and e.Sex = @gen";
            List<Employee> employees = new List<Employee>();
            try
            {
                var param = dataProvider.CreateParameter("@gen", 30, gen, DbType.String);
                reader = dataProvider.GetDataReader(query, CommandType.Text, out connection, param);
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Dob = reader.GetDateTime(2),
                        Sex = reader.GetString(3),
                        Position = reader.GetString(4),
                        Department = reader.GetInt32(5),
                        DepartmentName = reader.GetString(6)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                CloseConnection();
            }
            return employees;
        }

        public List<Employee> GetEmployeesByPOs(string pos)
        {
            IDataReader reader = null;
            string query = "select e.*, d.Name from Employee e, Department d where e.Department = d.Id" +
                " and e.Position = @pos";
            List<Employee> employees = new List<Employee>();
            try
            {
                var param = dataProvider.CreateParameter("@pos", 30, pos, DbType.String);
                reader = dataProvider.GetDataReader(query, CommandType.Text, out connection, param);
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Dob = reader.GetDateTime(2),
                        Sex = reader.GetString(3),
                        Position = reader.GetString(4),
                        Department = reader.GetInt32(5),
                        DepartmentName = reader.GetString(6)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                reader.Close();
                CloseConnection();
            }
            return employees;
        }
    }
}
