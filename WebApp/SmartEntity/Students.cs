using Chloe.Entity;
using Chloe.Oracle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartEntity
{
    [Serializable]
    [TableAttribute("Students")]
    public partial class Students
    {

        #region	属性

        private int _id;

        /// <summary>
        /// Id
        /// </summary>
        [Column(IsPrimaryKey = true)]
        [AutoIncrement]
        [Sequence("USERS_AUTOID")]//For oracle
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {               
                this._id = value;
            }
        }


        private string _name;

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {                
                this._name = value;
            }
        }


        #endregion
    }
}
