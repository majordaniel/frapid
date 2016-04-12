using Frapid.NPoco;
using Frapid.NPoco.FluentMappings;
using Newtonsoft.Json;

namespace Frapid.DataAccess.Models
{
    public class EntityColumn : IPoco
    {
        private string _columnName;
        private string _value;
        private string _nullable;
        private string _primaryKey;

        public string ColumnName
        {
            get { return this._columnName; }
            set
            {
                this._columnName = value;
                this.PropertyName = Inflector.ToTitleCase(value).Replace("_", "").Replace(" ", "");
            }
        }


        public string DbDataType { get; set; }

        #region Nullable
        [Ignore]
        public bool IsNullable { get; set; }
        [JsonIgnore]
        public string Nullable
        {
            get { return this._nullable; }
            set
            {
                this.IsNullable = value.ToUpperInvariant().Equals("YES");
                this._nullable = value;
            }
        }
        #endregion
        #region  Primary Key
        [Ignore]
        public bool IsPrimaryKey { get; set; }
        [JsonIgnore]
        public string PrimaryKey
        {
            get { return this._primaryKey; }
            set
            {
                this.IsPrimaryKey = value.ToUpperInvariant().Equals("YES");
                this._primaryKey = value;
            }
        }
        #endregion

        public string Value
        {
            get { return this._value; }
            set
            {
                this._value = value;
                if (value.StartsWith("nextval"))
                {
                    this.IsSerial = true;
                    this._value = string.Empty;
                }
            }
        }

        public int MaxLength { get; set; }
        public bool IsSerial { get; set; }
        public string PropertyName { get; set; }
        public string DataType { get; set; }
    }
}