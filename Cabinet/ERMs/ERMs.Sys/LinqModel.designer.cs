﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ERMs.Sys
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ERMS")]
	public partial class LinqModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertSys_Account(Sys_Account instance);
    partial void UpdateSys_Account(Sys_Account instance);
    partial void DeleteSys_Account(Sys_Account instance);
    #endregion
		
		public LinqModelDataContext() : 
				base(global::ERMs.Sys.Properties.Settings.Default.ERMSConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public LinqModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public LinqModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Sys_Account> Sys_Accounts
		{
			get
			{
				return this.GetTable<Sys_Account>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Sys_Account")]
	public partial class Sys_Account : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Code_tv;
		
		private string _name_tv;
		
		private string _name;
		
		private System.Nullable<bool> _man;
		
		private System.Nullable<System.DateTime> _dob;
		
		private string _noisinh;
		
		private string _quoctich;
		
		private string _pag_no;
		
		private string _pport_no;
		
		private string _noicap;
		
		private string _Group;
		
		private string _course;
		
		private string _main_base;
		
		private string _from_place;
		
		private System.Nullable<System.DateTime> _start_date;
		
		private System.Nullable<System.DateTime> _end_date;
		
		private string _home;
		
		private System.Nullable<char> _type_tv;
		
		private string _term_tv;
		
		private System.Nullable<char> _class_tv;
		
		private System.Nullable<bool> _ann;
		
		private string _lg;
		
		private string _on_plan;
		
		private string _on_route;
		
		private string _vip;
		
		private string _knbgoc;
		
		private string _kn_khac;
		
		private string _status;
		
		private string _baclg;
		
		private System.Nullable<System.DateTime> _ngaynhan;
		
		private System.Nullable<System.DateTime> _ngayve;
		
		private System.Nullable<float> _ttut;
		
		private System.Nullable<float> _ma_tt;
		
		private System.Nullable<int> _fly_time;
		
		private System.Nullable<int> _int_time;
		
		private System.Nullable<int> _duty_time;
		
		private System.Nullable<int> _sochbay;
		
		private System.Nullable<int> _dubi;
		
		private System.Nullable<int> _night;
		
		private System.Nullable<char> _lc;
		
		private System.Nullable<bool> _IsCrew;
		
		private string _Account;
		
		private string _CrewID;
		
		private string _FirstNameVn;
		
		private string _LastNameVn;
		
		private string _Phone;
		
		private string _Email;
		
		private string _ImageBase64;
		
		private string _Note;
		
		private string _Token;
		
		private System.Nullable<bool> _IsDeleted;
		
		private System.Nullable<System.DateTime> _Created;
		
		private System.Nullable<System.DateTime> _Modified;
		
		private string _Creator;
		
		private string _Modifier;
		
		private string _Creatorid;
		
		private string _Modifierid;
		
		private System.Nullable<System.DateTime> _PPort_Date;
		
		private System.Nullable<int> _InfoConfirmed;
		
		private System.Nullable<System.DateTime> _TokenExpired;
		
		private string _Ogranization;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnCode_tvChanging(string value);
    partial void OnCode_tvChanged();
    partial void Onname_tvChanging(string value);
    partial void Onname_tvChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnmanChanging(System.Nullable<bool> value);
    partial void OnmanChanged();
    partial void OndobChanging(System.Nullable<System.DateTime> value);
    partial void OndobChanged();
    partial void OnnoisinhChanging(string value);
    partial void OnnoisinhChanged();
    partial void OnquoctichChanging(string value);
    partial void OnquoctichChanged();
    partial void Onpag_noChanging(string value);
    partial void Onpag_noChanged();
    partial void Onpport_noChanging(string value);
    partial void Onpport_noChanged();
    partial void OnnoicapChanging(string value);
    partial void OnnoicapChanged();
    partial void OnGroupChanging(string value);
    partial void OnGroupChanged();
    partial void OncourseChanging(string value);
    partial void OncourseChanged();
    partial void Onmain_baseChanging(string value);
    partial void Onmain_baseChanged();
    partial void Onfrom_placeChanging(string value);
    partial void Onfrom_placeChanged();
    partial void Onstart_dateChanging(System.Nullable<System.DateTime> value);
    partial void Onstart_dateChanged();
    partial void Onend_dateChanging(System.Nullable<System.DateTime> value);
    partial void Onend_dateChanged();
    partial void OnhomeChanging(string value);
    partial void OnhomeChanged();
    partial void Ontype_tvChanging(System.Nullable<char> value);
    partial void Ontype_tvChanged();
    partial void Onterm_tvChanging(string value);
    partial void Onterm_tvChanged();
    partial void Onclass_tvChanging(System.Nullable<char> value);
    partial void Onclass_tvChanged();
    partial void OnannChanging(System.Nullable<bool> value);
    partial void OnannChanged();
    partial void OnlgChanging(string value);
    partial void OnlgChanged();
    partial void Onon_planChanging(string value);
    partial void Onon_planChanged();
    partial void Onon_routeChanging(string value);
    partial void Onon_routeChanged();
    partial void OnvipChanging(string value);
    partial void OnvipChanged();
    partial void OnknbgocChanging(string value);
    partial void OnknbgocChanged();
    partial void Onkn_khacChanging(string value);
    partial void Onkn_khacChanged();
    partial void OnstatusChanging(string value);
    partial void OnstatusChanged();
    partial void OnbaclgChanging(string value);
    partial void OnbaclgChanged();
    partial void OnngaynhanChanging(System.Nullable<System.DateTime> value);
    partial void OnngaynhanChanged();
    partial void OnngayveChanging(System.Nullable<System.DateTime> value);
    partial void OnngayveChanged();
    partial void OnttutChanging(System.Nullable<float> value);
    partial void OnttutChanged();
    partial void Onma_ttChanging(System.Nullable<float> value);
    partial void Onma_ttChanged();
    partial void Onfly_timeChanging(System.Nullable<int> value);
    partial void Onfly_timeChanged();
    partial void Onint_timeChanging(System.Nullable<int> value);
    partial void Onint_timeChanged();
    partial void Onduty_timeChanging(System.Nullable<int> value);
    partial void Onduty_timeChanged();
    partial void OnsochbayChanging(System.Nullable<int> value);
    partial void OnsochbayChanged();
    partial void OndubiChanging(System.Nullable<int> value);
    partial void OndubiChanged();
    partial void OnnightChanging(System.Nullable<int> value);
    partial void OnnightChanged();
    partial void OnlcChanging(System.Nullable<char> value);
    partial void OnlcChanged();
    partial void OnIsCrewChanging(System.Nullable<bool> value);
    partial void OnIsCrewChanged();
    partial void OnAccountChanging(string value);
    partial void OnAccountChanged();
    partial void OnCrewIDChanging(string value);
    partial void OnCrewIDChanged();
    partial void OnFirstNameVnChanging(string value);
    partial void OnFirstNameVnChanged();
    partial void OnLastNameVnChanging(string value);
    partial void OnLastNameVnChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnImageBase64Changing(string value);
    partial void OnImageBase64Changed();
    partial void OnNoteChanging(string value);
    partial void OnNoteChanged();
    partial void OnTokenChanging(string value);
    partial void OnTokenChanged();
    partial void OnIsDeletedChanging(System.Nullable<bool> value);
    partial void OnIsDeletedChanged();
    partial void OnCreatedChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedChanged();
    partial void OnModifiedChanging(System.Nullable<System.DateTime> value);
    partial void OnModifiedChanged();
    partial void OnCreatorChanging(string value);
    partial void OnCreatorChanged();
    partial void OnModifierChanging(string value);
    partial void OnModifierChanged();
    partial void OnCreatoridChanging(string value);
    partial void OnCreatoridChanged();
    partial void OnModifieridChanging(string value);
    partial void OnModifieridChanged();
    partial void OnPPort_DateChanging(System.Nullable<System.DateTime> value);
    partial void OnPPort_DateChanged();
    partial void OnInfoConfirmedChanging(System.Nullable<int> value);
    partial void OnInfoConfirmedChanged();
    partial void OnTokenExpiredChanging(System.Nullable<System.DateTime> value);
    partial void OnTokenExpiredChanged();
    partial void OnOgranizationChanging(string value);
    partial void OnOgranizationChanged();
    #endregion
		
		public Sys_Account()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Code_tv", DbType="VarChar(10)")]
		public string Code_tv
		{
			get
			{
				return this._Code_tv;
			}
			set
			{
				if ((this._Code_tv != value))
				{
					this.OnCode_tvChanging(value);
					this.SendPropertyChanging();
					this._Code_tv = value;
					this.SendPropertyChanged("Code_tv");
					this.OnCode_tvChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name_tv", DbType="NVarChar(100)")]
		public string name_tv
		{
			get
			{
				return this._name_tv;
			}
			set
			{
				if ((this._name_tv != value))
				{
					this.Onname_tvChanging(value);
					this.SendPropertyChanging();
					this._name_tv = value;
					this.SendPropertyChanged("name_tv");
					this.Onname_tvChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(100)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_man", DbType="Bit")]
		public System.Nullable<bool> man
		{
			get
			{
				return this._man;
			}
			set
			{
				if ((this._man != value))
				{
					this.OnmanChanging(value);
					this.SendPropertyChanging();
					this._man = value;
					this.SendPropertyChanged("man");
					this.OnmanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dob", DbType="Date")]
		public System.Nullable<System.DateTime> dob
		{
			get
			{
				return this._dob;
			}
			set
			{
				if ((this._dob != value))
				{
					this.OndobChanging(value);
					this.SendPropertyChanging();
					this._dob = value;
					this.SendPropertyChanged("dob");
					this.OndobChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_noisinh", DbType="NVarChar(200)")]
		public string noisinh
		{
			get
			{
				return this._noisinh;
			}
			set
			{
				if ((this._noisinh != value))
				{
					this.OnnoisinhChanging(value);
					this.SendPropertyChanging();
					this._noisinh = value;
					this.SendPropertyChanged("noisinh");
					this.OnnoisinhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_quoctich", DbType="NVarChar(50)")]
		public string quoctich
		{
			get
			{
				return this._quoctich;
			}
			set
			{
				if ((this._quoctich != value))
				{
					this.OnquoctichChanging(value);
					this.SendPropertyChanging();
					this._quoctich = value;
					this.SendPropertyChanged("quoctich");
					this.OnquoctichChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pag_no", DbType="VarChar(50)")]
		public string pag_no
		{
			get
			{
				return this._pag_no;
			}
			set
			{
				if ((this._pag_no != value))
				{
					this.Onpag_noChanging(value);
					this.SendPropertyChanging();
					this._pag_no = value;
					this.SendPropertyChanged("pag_no");
					this.Onpag_noChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pport_no", DbType="VarChar(50)")]
		public string pport_no
		{
			get
			{
				return this._pport_no;
			}
			set
			{
				if ((this._pport_no != value))
				{
					this.Onpport_noChanging(value);
					this.SendPropertyChanging();
					this._pport_no = value;
					this.SendPropertyChanged("pport_no");
					this.Onpport_noChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_noicap", DbType="NVarChar(50)")]
		public string noicap
		{
			get
			{
				return this._noicap;
			}
			set
			{
				if ((this._noicap != value))
				{
					this.OnnoicapChanging(value);
					this.SendPropertyChanging();
					this._noicap = value;
					this.SendPropertyChanged("noicap");
					this.OnnoicapChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Group]", Storage="_Group", DbType="VarChar(5)")]
		public string Group
		{
			get
			{
				return this._Group;
			}
			set
			{
				if ((this._Group != value))
				{
					this.OnGroupChanging(value);
					this.SendPropertyChanging();
					this._Group = value;
					this.SendPropertyChanged("Group");
					this.OnGroupChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_course", DbType="VarChar(5)")]
		public string course
		{
			get
			{
				return this._course;
			}
			set
			{
				if ((this._course != value))
				{
					this.OncourseChanging(value);
					this.SendPropertyChanging();
					this._course = value;
					this.SendPropertyChanged("course");
					this.OncourseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_main_base", DbType="VarChar(5)")]
		public string main_base
		{
			get
			{
				return this._main_base;
			}
			set
			{
				if ((this._main_base != value))
				{
					this.Onmain_baseChanging(value);
					this.SendPropertyChanging();
					this._main_base = value;
					this.SendPropertyChanged("main_base");
					this.Onmain_baseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_from_place", DbType="VarChar(5)")]
		public string from_place
		{
			get
			{
				return this._from_place;
			}
			set
			{
				if ((this._from_place != value))
				{
					this.Onfrom_placeChanging(value);
					this.SendPropertyChanging();
					this._from_place = value;
					this.SendPropertyChanged("from_place");
					this.Onfrom_placeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_start_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> start_date
		{
			get
			{
				return this._start_date;
			}
			set
			{
				if ((this._start_date != value))
				{
					this.Onstart_dateChanging(value);
					this.SendPropertyChanging();
					this._start_date = value;
					this.SendPropertyChanged("start_date");
					this.Onstart_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_end_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> end_date
		{
			get
			{
				return this._end_date;
			}
			set
			{
				if ((this._end_date != value))
				{
					this.Onend_dateChanging(value);
					this.SendPropertyChanging();
					this._end_date = value;
					this.SendPropertyChanged("end_date");
					this.Onend_dateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_home", DbType="VarChar(5)")]
		public string home
		{
			get
			{
				return this._home;
			}
			set
			{
				if ((this._home != value))
				{
					this.OnhomeChanging(value);
					this.SendPropertyChanging();
					this._home = value;
					this.SendPropertyChanged("home");
					this.OnhomeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type_tv", DbType="Char(1)")]
		public System.Nullable<char> type_tv
		{
			get
			{
				return this._type_tv;
			}
			set
			{
				if ((this._type_tv != value))
				{
					this.Ontype_tvChanging(value);
					this.SendPropertyChanging();
					this._type_tv = value;
					this.SendPropertyChanged("type_tv");
					this.Ontype_tvChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_term_tv", DbType="VarChar(50)")]
		public string term_tv
		{
			get
			{
				return this._term_tv;
			}
			set
			{
				if ((this._term_tv != value))
				{
					this.Onterm_tvChanging(value);
					this.SendPropertyChanging();
					this._term_tv = value;
					this.SendPropertyChanged("term_tv");
					this.Onterm_tvChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_class_tv", DbType="Char(1)")]
		public System.Nullable<char> class_tv
		{
			get
			{
				return this._class_tv;
			}
			set
			{
				if ((this._class_tv != value))
				{
					this.Onclass_tvChanging(value);
					this.SendPropertyChanging();
					this._class_tv = value;
					this.SendPropertyChanged("class_tv");
					this.Onclass_tvChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ann", DbType="Bit")]
		public System.Nullable<bool> ann
		{
			get
			{
				return this._ann;
			}
			set
			{
				if ((this._ann != value))
				{
					this.OnannChanging(value);
					this.SendPropertyChanging();
					this._ann = value;
					this.SendPropertyChanged("ann");
					this.OnannChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lg", DbType="VarChar(5)")]
		public string lg
		{
			get
			{
				return this._lg;
			}
			set
			{
				if ((this._lg != value))
				{
					this.OnlgChanging(value);
					this.SendPropertyChanging();
					this._lg = value;
					this.SendPropertyChanged("lg");
					this.OnlgChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_on_plan", DbType="NVarChar(100)")]
		public string on_plan
		{
			get
			{
				return this._on_plan;
			}
			set
			{
				if ((this._on_plan != value))
				{
					this.Onon_planChanging(value);
					this.SendPropertyChanging();
					this._on_plan = value;
					this.SendPropertyChanged("on_plan");
					this.Onon_planChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_on_route", DbType="VarChar(5)")]
		public string on_route
		{
			get
			{
				return this._on_route;
			}
			set
			{
				if ((this._on_route != value))
				{
					this.Onon_routeChanging(value);
					this.SendPropertyChanging();
					this._on_route = value;
					this.SendPropertyChanged("on_route");
					this.Onon_routeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vip", DbType="NVarChar(50)")]
		public string vip
		{
			get
			{
				return this._vip;
			}
			set
			{
				if ((this._vip != value))
				{
					this.OnvipChanging(value);
					this.SendPropertyChanging();
					this._vip = value;
					this.SendPropertyChanged("vip");
					this.OnvipChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_knbgoc", DbType="NVarChar(100)")]
		public string knbgoc
		{
			get
			{
				return this._knbgoc;
			}
			set
			{
				if ((this._knbgoc != value))
				{
					this.OnknbgocChanging(value);
					this.SendPropertyChanging();
					this._knbgoc = value;
					this.SendPropertyChanged("knbgoc");
					this.OnknbgocChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kn_khac", DbType="VarChar(50)")]
		public string kn_khac
		{
			get
			{
				return this._kn_khac;
			}
			set
			{
				if ((this._kn_khac != value))
				{
					this.Onkn_khacChanging(value);
					this.SendPropertyChanging();
					this._kn_khac = value;
					this.SendPropertyChanged("kn_khac");
					this.Onkn_khacChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="Char(2)")]
		public string status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_baclg", DbType="VarChar(50)")]
		public string baclg
		{
			get
			{
				return this._baclg;
			}
			set
			{
				if ((this._baclg != value))
				{
					this.OnbaclgChanging(value);
					this.SendPropertyChanging();
					this._baclg = value;
					this.SendPropertyChanged("baclg");
					this.OnbaclgChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngaynhan", DbType="Date")]
		public System.Nullable<System.DateTime> ngaynhan
		{
			get
			{
				return this._ngaynhan;
			}
			set
			{
				if ((this._ngaynhan != value))
				{
					this.OnngaynhanChanging(value);
					this.SendPropertyChanging();
					this._ngaynhan = value;
					this.SendPropertyChanged("ngaynhan");
					this.OnngaynhanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngayve", DbType="Date")]
		public System.Nullable<System.DateTime> ngayve
		{
			get
			{
				return this._ngayve;
			}
			set
			{
				if ((this._ngayve != value))
				{
					this.OnngayveChanging(value);
					this.SendPropertyChanging();
					this._ngayve = value;
					this.SendPropertyChanged("ngayve");
					this.OnngayveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ttut", DbType="Real")]
		public System.Nullable<float> ttut
		{
			get
			{
				return this._ttut;
			}
			set
			{
				if ((this._ttut != value))
				{
					this.OnttutChanging(value);
					this.SendPropertyChanging();
					this._ttut = value;
					this.SendPropertyChanged("ttut");
					this.OnttutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ma_tt", DbType="Real")]
		public System.Nullable<float> ma_tt
		{
			get
			{
				return this._ma_tt;
			}
			set
			{
				if ((this._ma_tt != value))
				{
					this.Onma_ttChanging(value);
					this.SendPropertyChanging();
					this._ma_tt = value;
					this.SendPropertyChanged("ma_tt");
					this.Onma_ttChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fly_time", DbType="Int")]
		public System.Nullable<int> fly_time
		{
			get
			{
				return this._fly_time;
			}
			set
			{
				if ((this._fly_time != value))
				{
					this.Onfly_timeChanging(value);
					this.SendPropertyChanging();
					this._fly_time = value;
					this.SendPropertyChanged("fly_time");
					this.Onfly_timeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_int_time", DbType="Int")]
		public System.Nullable<int> int_time
		{
			get
			{
				return this._int_time;
			}
			set
			{
				if ((this._int_time != value))
				{
					this.Onint_timeChanging(value);
					this.SendPropertyChanging();
					this._int_time = value;
					this.SendPropertyChanged("int_time");
					this.Onint_timeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_duty_time", DbType="Int")]
		public System.Nullable<int> duty_time
		{
			get
			{
				return this._duty_time;
			}
			set
			{
				if ((this._duty_time != value))
				{
					this.Onduty_timeChanging(value);
					this.SendPropertyChanging();
					this._duty_time = value;
					this.SendPropertyChanged("duty_time");
					this.Onduty_timeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sochbay", DbType="Int")]
		public System.Nullable<int> sochbay
		{
			get
			{
				return this._sochbay;
			}
			set
			{
				if ((this._sochbay != value))
				{
					this.OnsochbayChanging(value);
					this.SendPropertyChanging();
					this._sochbay = value;
					this.SendPropertyChanged("sochbay");
					this.OnsochbayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dubi", DbType="Int")]
		public System.Nullable<int> dubi
		{
			get
			{
				return this._dubi;
			}
			set
			{
				if ((this._dubi != value))
				{
					this.OndubiChanging(value);
					this.SendPropertyChanging();
					this._dubi = value;
					this.SendPropertyChanged("dubi");
					this.OndubiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_night", DbType="Int")]
		public System.Nullable<int> night
		{
			get
			{
				return this._night;
			}
			set
			{
				if ((this._night != value))
				{
					this.OnnightChanging(value);
					this.SendPropertyChanging();
					this._night = value;
					this.SendPropertyChanged("night");
					this.OnnightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lc", DbType="Char(1)")]
		public System.Nullable<char> lc
		{
			get
			{
				return this._lc;
			}
			set
			{
				if ((this._lc != value))
				{
					this.OnlcChanging(value);
					this.SendPropertyChanging();
					this._lc = value;
					this.SendPropertyChanged("lc");
					this.OnlcChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsCrew", DbType="Bit")]
		public System.Nullable<bool> IsCrew
		{
			get
			{
				return this._IsCrew;
			}
			set
			{
				if ((this._IsCrew != value))
				{
					this.OnIsCrewChanging(value);
					this.SendPropertyChanging();
					this._IsCrew = value;
					this.SendPropertyChanged("IsCrew");
					this.OnIsCrewChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Account", DbType="VarChar(50)")]
		public string Account
		{
			get
			{
				return this._Account;
			}
			set
			{
				if ((this._Account != value))
				{
					this.OnAccountChanging(value);
					this.SendPropertyChanging();
					this._Account = value;
					this.SendPropertyChanged("Account");
					this.OnAccountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CrewID", DbType="VarChar(10)")]
		public string CrewID
		{
			get
			{
				return this._CrewID;
			}
			set
			{
				if ((this._CrewID != value))
				{
					this.OnCrewIDChanging(value);
					this.SendPropertyChanging();
					this._CrewID = value;
					this.SendPropertyChanged("CrewID");
					this.OnCrewIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstNameVn", DbType="NVarChar(50)")]
		public string FirstNameVn
		{
			get
			{
				return this._FirstNameVn;
			}
			set
			{
				if ((this._FirstNameVn != value))
				{
					this.OnFirstNameVnChanging(value);
					this.SendPropertyChanging();
					this._FirstNameVn = value;
					this.SendPropertyChanged("FirstNameVn");
					this.OnFirstNameVnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastNameVn", DbType="NVarChar(200)")]
		public string LastNameVn
		{
			get
			{
				return this._LastNameVn;
			}
			set
			{
				if ((this._LastNameVn != value))
				{
					this.OnLastNameVnChanging(value);
					this.SendPropertyChanging();
					this._LastNameVn = value;
					this.SendPropertyChanged("LastNameVn");
					this.OnLastNameVnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="VarChar(50)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(250)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImageBase64", DbType="NVarChar(4000)")]
		public string ImageBase64
		{
			get
			{
				return this._ImageBase64;
			}
			set
			{
				if ((this._ImageBase64 != value))
				{
					this.OnImageBase64Changing(value);
					this.SendPropertyChanging();
					this._ImageBase64 = value;
					this.SendPropertyChanged("ImageBase64");
					this.OnImageBase64Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Note", DbType="NVarChar(1000)")]
		public string Note
		{
			get
			{
				return this._Note;
			}
			set
			{
				if ((this._Note != value))
				{
					this.OnNoteChanging(value);
					this.SendPropertyChanging();
					this._Note = value;
					this.SendPropertyChanged("Note");
					this.OnNoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Token", DbType="VarChar(50)")]
		public string Token
		{
			get
			{
				return this._Token;
			}
			set
			{
				if ((this._Token != value))
				{
					this.OnTokenChanging(value);
					this.SendPropertyChanging();
					this._Token = value;
					this.SendPropertyChanged("Token");
					this.OnTokenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsDeleted", DbType="Bit")]
		public System.Nullable<bool> IsDeleted
		{
			get
			{
				return this._IsDeleted;
			}
			set
			{
				if ((this._IsDeleted != value))
				{
					this.OnIsDeletedChanging(value);
					this.SendPropertyChanging();
					this._IsDeleted = value;
					this.SendPropertyChanged("IsDeleted");
					this.OnIsDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Created", DbType="DateTime")]
		public System.Nullable<System.DateTime> Created
		{
			get
			{
				return this._Created;
			}
			set
			{
				if ((this._Created != value))
				{
					this.OnCreatedChanging(value);
					this.SendPropertyChanging();
					this._Created = value;
					this.SendPropertyChanged("Created");
					this.OnCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Modified", DbType="DateTime")]
		public System.Nullable<System.DateTime> Modified
		{
			get
			{
				return this._Modified;
			}
			set
			{
				if ((this._Modified != value))
				{
					this.OnModifiedChanging(value);
					this.SendPropertyChanging();
					this._Modified = value;
					this.SendPropertyChanged("Modified");
					this.OnModifiedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Creator", DbType="NVarChar(100)")]
		public string Creator
		{
			get
			{
				return this._Creator;
			}
			set
			{
				if ((this._Creator != value))
				{
					this.OnCreatorChanging(value);
					this.SendPropertyChanging();
					this._Creator = value;
					this.SendPropertyChanged("Creator");
					this.OnCreatorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Modifier", DbType="NVarChar(100)")]
		public string Modifier
		{
			get
			{
				return this._Modifier;
			}
			set
			{
				if ((this._Modifier != value))
				{
					this.OnModifierChanging(value);
					this.SendPropertyChanging();
					this._Modifier = value;
					this.SendPropertyChanged("Modifier");
					this.OnModifierChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Creatorid", DbType="VarChar(50)")]
		public string Creatorid
		{
			get
			{
				return this._Creatorid;
			}
			set
			{
				if ((this._Creatorid != value))
				{
					this.OnCreatoridChanging(value);
					this.SendPropertyChanging();
					this._Creatorid = value;
					this.SendPropertyChanged("Creatorid");
					this.OnCreatoridChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Modifierid", DbType="VarChar(50)")]
		public string Modifierid
		{
			get
			{
				return this._Modifierid;
			}
			set
			{
				if ((this._Modifierid != value))
				{
					this.OnModifieridChanging(value);
					this.SendPropertyChanging();
					this._Modifierid = value;
					this.SendPropertyChanged("Modifierid");
					this.OnModifieridChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PPort_Date", DbType="DateTime")]
		public System.Nullable<System.DateTime> PPort_Date
		{
			get
			{
				return this._PPort_Date;
			}
			set
			{
				if ((this._PPort_Date != value))
				{
					this.OnPPort_DateChanging(value);
					this.SendPropertyChanging();
					this._PPort_Date = value;
					this.SendPropertyChanged("PPort_Date");
					this.OnPPort_DateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InfoConfirmed", DbType="Int")]
		public System.Nullable<int> InfoConfirmed
		{
			get
			{
				return this._InfoConfirmed;
			}
			set
			{
				if ((this._InfoConfirmed != value))
				{
					this.OnInfoConfirmedChanging(value);
					this.SendPropertyChanging();
					this._InfoConfirmed = value;
					this.SendPropertyChanged("InfoConfirmed");
					this.OnInfoConfirmedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TokenExpired", DbType="DateTime")]
		public System.Nullable<System.DateTime> TokenExpired
		{
			get
			{
				return this._TokenExpired;
			}
			set
			{
				if ((this._TokenExpired != value))
				{
					this.OnTokenExpiredChanging(value);
					this.SendPropertyChanging();
					this._TokenExpired = value;
					this.SendPropertyChanged("TokenExpired");
					this.OnTokenExpiredChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ogranization", DbType="VarChar(500)")]
		public string Ogranization
		{
			get
			{
				return this._Ogranization;
			}
			set
			{
				if ((this._Ogranization != value))
				{
					this.OnOgranizationChanging(value);
					this.SendPropertyChanging();
					this._Ogranization = value;
					this.SendPropertyChanged("Ogranization");
					this.OnOgranizationChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
