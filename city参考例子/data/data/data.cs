namespace Example.Model {
    	using System;
    	
    	
    	/// <summary>
    	/// 表名：data 主键列：id
    	/// </summary>
    	[SerializableAttribute()]
    	public partial class data : MySoft.Data.Entity {
    		
    		protected Int64 _id;
    		
    		protected String _display;
    		
    		protected String _name;
    		
    		protected Int64? _parentId;
    		
    		protected String _shortName;
    		
    		protected Int32? _type;
    		
    		public Int64 id {
    			get {
    				return this._id;
    			}
    			set {
    				this.OnPropertyValueChange(_.id, _id, value);
    				this._id = value;
    			}
    		}
    		
    		public String display {
    			get {
    				return this._display;
    			}
    			set {
    				this.OnPropertyValueChange(_.display, _display, value);
    				this._display = value;
    			}
    		}
    		
    		public String name {
    			get {
    				return this._name;
    			}
    			set {
    				this.OnPropertyValueChange(_.name, _name, value);
    				this._name = value;
    			}
    		}
    		
    		public Int64? parentId {
    			get {
    				return this._parentId;
    			}
    			set {
    				this.OnPropertyValueChange(_.parentId, _parentId, value);
    				this._parentId = value;
    			}
    		}
    		
    		public String shortName {
    			get {
    				return this._shortName;
    			}
    			set {
    				this.OnPropertyValueChange(_.shortName, _shortName, value);
    				this._shortName = value;
    			}
    		}
    		
    		public Int32? type {
    			get {
    				return this._type;
    			}
    			set {
    				this.OnPropertyValueChange(_.type, _type, value);
    				this._type = value;
    			}
    		}
    		
    		/// <summary>
    		/// 获取实体对应的表名
    		/// </summary>
    		protected override MySoft.Data.Table GetTable() {
    			return new MySoft.Data.Table<data>("data");
    		}
    		
    		/// <summary>
    		/// 获取实体中的主键列
    		/// </summary>
    		protected override MySoft.Data.Field[] GetPrimaryKeyFields() {
    			return new MySoft.Data.Field[] {
    					_.id};
    		}
    		
    		/// <summary>
    		/// 获取列信息
    		/// </summary>
    		protected override MySoft.Data.Field[] GetFields() {
    			return new MySoft.Data.Field[] {
    					_.id,
    					_.display,
    					_.name,
    					_.parentId,
    					_.shortName,
    					_.type};
    		}
    		
    		/// <summary>
    		/// 获取列数据
    		/// </summary>
    		protected override object[] GetValues() {
    			return new object[] {
    					this._id,
    					this._display,
    					this._name,
    					this._parentId,
    					this._shortName,
    					this._type};
    		}
    		
    		/// <summary>
    		/// 给当前实体赋值
    		/// </summary>
    		protected override void SetValues(MySoft.Data.IRowReader reader) {
    			if ((false == reader.IsDBNull(_.id))) {
    				this._id = reader.GetInt64(_.id);
    			}
    			if ((false == reader.IsDBNull(_.display))) {
    				this._display = reader.GetString(_.display);
    			}
    			if ((false == reader.IsDBNull(_.name))) {
    				this._name = reader.GetString(_.name);
    			}
    			if ((false == reader.IsDBNull(_.parentId))) {
    				this._parentId = reader.GetInt64(_.parentId);
    			}
    			if ((false == reader.IsDBNull(_.shortName))) {
    				this._shortName = reader.GetString(_.shortName);
    			}
    			if ((false == reader.IsDBNull(_.type))) {
    				this._type = reader.GetInt32(_.type);
    			}
    		}
    		
    		public override int GetHashCode() {
    			return base.GetHashCode();
    		}
    		
    		public override bool Equals(object obj) {
    			if ((obj == null)) {
    				return false;
    			}
    			if ((false == typeof(data).IsAssignableFrom(obj.GetType()))) {
    				return false;
    			}
    			if ((((object)(this)) == ((object)(obj)))) {
    				return true;
    			}
    			return false;
    		}
    		
    		public class _ {
    			
    			/// <summary>
    			/// 表示选择所有列，与*等同
    			/// </summary>
    			public static MySoft.Data.AllField All = new MySoft.Data.AllField<data>();
    			
    			/// <summary>
    			/// 字段名：id - 数据类型：Int64
    			/// </summary>
    			public static MySoft.Data.Field id = new MySoft.Data.Field<data>("id");
    			
    			/// <summary>
    			/// 字段名：display - 数据类型：String
    			/// </summary>
    			public static MySoft.Data.Field display = new MySoft.Data.Field<data>("display");
    			
    			/// <summary>
    			/// 字段名：name - 数据类型：String
    			/// </summary>
    			public static MySoft.Data.Field name = new MySoft.Data.Field<data>("name");
    			
    			/// <summary>
    			/// 字段名：parentId - 数据类型：Int64(可空)
    			/// </summary>
    			public static MySoft.Data.Field parentId = new MySoft.Data.Field<data>("parentId");
    			
    			/// <summary>
    			/// 字段名：shortName - 数据类型：String
    			/// </summary>
    			public static MySoft.Data.Field shortName = new MySoft.Data.Field<data>("shortName");
    			
    			/// <summary>
    			/// 字段名：type - 数据类型：Int32(可空)
    			/// </summary>
    			public static MySoft.Data.Field type = new MySoft.Data.Field<data>("type");
    		}
    	}
    }
