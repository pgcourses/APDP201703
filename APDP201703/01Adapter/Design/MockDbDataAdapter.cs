using _01Adapter.Resource;
using System;
using System.Data;

namespace _01Adapter
{
    public class MockDbDataAdapter : IDbDataAdapter
    {

        public int Fill(DataSet dataSet)
        {
            if (dataSet == null) { throw new ArgumentNullException(nameof(dataSet)); }

            var dataTable = new DataTable();

            dataTable.Columns.Add(GlobalStrings.TableColumnEMailAddress, typeof(string));
            var row = dataTable.NewRow();
            row[GlobalStrings.TableColumnEMailAddress] = GlobalStrings.TesztEmailAddress;
            dataTable.Rows.Add(row);

            dataSet.Tables.Add(dataTable);
            dataSet.AcceptChanges();

            return 0;
        }

        #region not implemented
        public IDbCommand DeleteCommand
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IDbCommand InsertCommand
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public MissingMappingAction MissingMappingAction
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public MissingSchemaAction MissingSchemaAction
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IDbCommand SelectCommand
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ITableMappingCollection TableMappings
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IDbCommand UpdateCommand
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
        {
            throw new NotImplementedException();
        }

        public IDataParameter[] GetFillParameters()
        {
            throw new NotImplementedException();
        }

        public int Update(DataSet dataSet)
        {
            throw new NotImplementedException();
        }
        #endregion not implemented
    }
}