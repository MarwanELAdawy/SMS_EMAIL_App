﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("SMS_EMAIL_DB_Model", "FK_tbl_Emails_tbl_Users", "tbl_Users", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(SMS_EMAIL_DB_Model.tbl_Users), "tbl_Emails_SMS", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(SMS_EMAIL_DB_Model.tbl_Emails_SMS), true)]

#endregion

namespace SMS_EMAIL_DB_Model
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class SMS_EMAIL_DB_Entities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new SMS_EMAIL_DB_Entities object using the connection string found in the 'SMS_EMAIL_DB_Entities' section of the application configuration file.
        /// </summary>
        public SMS_EMAIL_DB_Entities() : base("name=SMS_EMAIL_DB_Entities", "SMS_EMAIL_DB_Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SMS_EMAIL_DB_Entities object.
        /// </summary>
        public SMS_EMAIL_DB_Entities(string connectionString) : base(connectionString, "SMS_EMAIL_DB_Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new SMS_EMAIL_DB_Entities object.
        /// </summary>
        public SMS_EMAIL_DB_Entities(EntityConnection connection) : base(connection, "SMS_EMAIL_DB_Entities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<tbl_Users> tbl_Users
        {
            get
            {
                if ((_tbl_Users == null))
                {
                    _tbl_Users = base.CreateObjectSet<tbl_Users>("tbl_Users");
                }
                return _tbl_Users;
            }
        }
        private ObjectSet<tbl_Users> _tbl_Users;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<tbl_Templates> tbl_Templates
        {
            get
            {
                if ((_tbl_Templates == null))
                {
                    _tbl_Templates = base.CreateObjectSet<tbl_Templates>("tbl_Templates");
                }
                return _tbl_Templates;
            }
        }
        private ObjectSet<tbl_Templates> _tbl_Templates;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<tbl_Emails_SMS> tbl_Emails_SMS
        {
            get
            {
                if ((_tbl_Emails_SMS == null))
                {
                    _tbl_Emails_SMS = base.CreateObjectSet<tbl_Emails_SMS>("tbl_Emails_SMS");
                }
                return _tbl_Emails_SMS;
            }
        }
        private ObjectSet<tbl_Emails_SMS> _tbl_Emails_SMS;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the tbl_Users EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTotbl_Users(tbl_Users tbl_Users)
        {
            base.AddObject("tbl_Users", tbl_Users);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the tbl_Templates EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTotbl_Templates(tbl_Templates tbl_Templates)
        {
            base.AddObject("tbl_Templates", tbl_Templates);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the tbl_Emails_SMS EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTotbl_Emails_SMS(tbl_Emails_SMS tbl_Emails_SMS)
        {
            base.AddObject("tbl_Emails_SMS", tbl_Emails_SMS);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SMS_EMAIL_DB_Model", Name="tbl_Emails_SMS")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tbl_Emails_SMS : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new tbl_Emails_SMS object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="type">Initial value of the Type property.</param>
        /// <param name="text">Initial value of the Text property.</param>
        /// <param name="user_Id">Initial value of the User_Id property.</param>
        /// <param name="created_At">Initial value of the Created_At property.</param>
        public static tbl_Emails_SMS Createtbl_Emails_SMS(global::System.Int32 id, global::System.String type, global::System.String text, global::System.Int32 user_Id, global::System.DateTime created_At)
        {
            tbl_Emails_SMS tbl_Emails_SMS = new tbl_Emails_SMS();
            tbl_Emails_SMS.Id = id;
            tbl_Emails_SMS.Type = type;
            tbl_Emails_SMS.Text = text;
            tbl_Emails_SMS.User_Id = user_Id;
            tbl_Emails_SMS.Created_At = created_At;
            return tbl_Emails_SMS;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Mobile_Number
        {
            get
            {
                return _Mobile_Number;
            }
            set
            {
                OnMobile_NumberChanging(value);
                ReportPropertyChanging("Mobile_Number");
                _Mobile_Number = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Mobile_Number");
                OnMobile_NumberChanged();
            }
        }
        private global::System.String _Mobile_Number;
        partial void OnMobile_NumberChanging(global::System.String value);
        partial void OnMobile_NumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Type
        {
            get
            {
                return _Type;
            }
            set
            {
                OnTypeChanging(value);
                ReportPropertyChanging("Type");
                _Type = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Type");
                OnTypeChanged();
            }
        }
        private global::System.String _Type;
        partial void OnTypeChanging(global::System.String value);
        partial void OnTypeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Claim_Number
        {
            get
            {
                return _Claim_Number;
            }
            set
            {
                OnClaim_NumberChanging(value);
                ReportPropertyChanging("Claim_Number");
                _Claim_Number = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Claim_Number");
                OnClaim_NumberChanged();
            }
        }
        private global::System.String _Claim_Number;
        partial void OnClaim_NumberChanging(global::System.String value);
        partial void OnClaim_NumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Policy_Number
        {
            get
            {
                return _Policy_Number;
            }
            set
            {
                OnPolicy_NumberChanging(value);
                ReportPropertyChanging("Policy_Number");
                _Policy_Number = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Policy_Number");
                OnPolicy_NumberChanged();
            }
        }
        private global::System.String _Policy_Number;
        partial void OnPolicy_NumberChanging(global::System.String value);
        partial void OnPolicy_NumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TP_ID
        {
            get
            {
                return _TP_ID;
            }
            set
            {
                OnTP_IDChanging(value);
                ReportPropertyChanging("TP_ID");
                _TP_ID = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TP_ID");
                OnTP_IDChanged();
            }
        }
        private global::System.String _TP_ID;
        partial void OnTP_IDChanging(global::System.String value);
        partial void OnTP_IDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TP_Name
        {
            get
            {
                return _TP_Name;
            }
            set
            {
                OnTP_NameChanging(value);
                ReportPropertyChanging("TP_Name");
                _TP_Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TP_Name");
                OnTP_NameChanged();
            }
        }
        private global::System.String _TP_Name;
        partial void OnTP_NameChanging(global::System.String value);
        partial void OnTP_NameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Email_Subject
        {
            get
            {
                return _Email_Subject;
            }
            set
            {
                OnEmail_SubjectChanging(value);
                ReportPropertyChanging("Email_Subject");
                _Email_Subject = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Email_Subject");
                OnEmail_SubjectChanged();
            }
        }
        private global::System.String _Email_Subject;
        partial void OnEmail_SubjectChanging(global::System.String value);
        partial void OnEmail_SubjectChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                OnTextChanging(value);
                ReportPropertyChanging("Text");
                _Text = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Text");
                OnTextChanged();
            }
        }
        private global::System.String _Text;
        partial void OnTextChanging(global::System.String value);
        partial void OnTextChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SMS_Language
        {
            get
            {
                return _SMS_Language;
            }
            set
            {
                OnSMS_LanguageChanging(value);
                ReportPropertyChanging("SMS_Language");
                _SMS_Language = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SMS_Language");
                OnSMS_LanguageChanged();
            }
        }
        private global::System.String _SMS_Language;
        partial void OnSMS_LanguageChanging(global::System.String value);
        partial void OnSMS_LanguageChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SMS_Code
        {
            get
            {
                return _SMS_Code;
            }
            set
            {
                OnSMS_CodeChanging(value);
                ReportPropertyChanging("SMS_Code");
                _SMS_Code = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SMS_Code");
                OnSMS_CodeChanged();
            }
        }
        private global::System.String _SMS_Code;
        partial void OnSMS_CodeChanging(global::System.String value);
        partial void OnSMS_CodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SMS_Code_Decode
        {
            get
            {
                return _SMS_Code_Decode;
            }
            set
            {
                OnSMS_Code_DecodeChanging(value);
                ReportPropertyChanging("SMS_Code_Decode");
                _SMS_Code_Decode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SMS_Code_Decode");
                OnSMS_Code_DecodeChanged();
            }
        }
        private global::System.String _SMS_Code_Decode;
        partial void OnSMS_Code_DecodeChanging(global::System.String value);
        partial void OnSMS_Code_DecodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 User_Id
        {
            get
            {
                return _User_Id;
            }
            set
            {
                OnUser_IdChanging(value);
                ReportPropertyChanging("User_Id");
                _User_Id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("User_Id");
                OnUser_IdChanged();
            }
        }
        private global::System.Int32 _User_Id;
        partial void OnUser_IdChanging(global::System.Int32 value);
        partial void OnUser_IdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> TemplateId
        {
            get
            {
                return _TemplateId;
            }
            set
            {
                OnTemplateIdChanging(value);
                ReportPropertyChanging("TemplateId");
                _TemplateId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TemplateId");
                OnTemplateIdChanged();
            }
        }
        private Nullable<global::System.Int64> _TemplateId;
        partial void OnTemplateIdChanging(Nullable<global::System.Int64> value);
        partial void OnTemplateIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Created_At
        {
            get
            {
                return _Created_At;
            }
            set
            {
                OnCreated_AtChanging(value);
                ReportPropertyChanging("Created_At");
                _Created_At = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Created_At");
                OnCreated_AtChanged();
            }
        }
        private global::System.DateTime _Created_At;
        partial void OnCreated_AtChanging(global::System.DateTime value);
        partial void OnCreated_AtChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("SMS_EMAIL_DB_Model", "FK_tbl_Emails_tbl_Users", "tbl_Users")]
        public tbl_Users tbl_Users
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tbl_Users>("SMS_EMAIL_DB_Model.FK_tbl_Emails_tbl_Users", "tbl_Users").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tbl_Users>("SMS_EMAIL_DB_Model.FK_tbl_Emails_tbl_Users", "tbl_Users").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<tbl_Users> tbl_UsersReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<tbl_Users>("SMS_EMAIL_DB_Model.FK_tbl_Emails_tbl_Users", "tbl_Users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<tbl_Users>("SMS_EMAIL_DB_Model.FK_tbl_Emails_tbl_Users", "tbl_Users", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SMS_EMAIL_DB_Model", Name="tbl_Templates")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tbl_Templates : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new tbl_Templates object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="language">Initial value of the Language property.</param>
        /// <param name="text">Initial value of the Text property.</param>
        /// <param name="createdAt">Initial value of the CreatedAt property.</param>
        /// <param name="updatedAt">Initial value of the UpdatedAt property.</param>
        public static tbl_Templates Createtbl_Templates(global::System.Int64 id, global::System.String language, global::System.String text, global::System.DateTime createdAt, global::System.DateTime updatedAt)
        {
            tbl_Templates tbl_Templates = new tbl_Templates();
            tbl_Templates.Id = id;
            tbl_Templates.Language = language;
            tbl_Templates.Text = text;
            tbl_Templates.CreatedAt = createdAt;
            tbl_Templates.UpdatedAt = updatedAt;
            return tbl_Templates;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int64 _Id;
        partial void OnIdChanging(global::System.Int64 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Language
        {
            get
            {
                return _Language;
            }
            set
            {
                OnLanguageChanging(value);
                ReportPropertyChanging("Language");
                _Language = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Language");
                OnLanguageChanged();
            }
        }
        private global::System.String _Language;
        partial void OnLanguageChanging(global::System.String value);
        partial void OnLanguageChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                OnTextChanging(value);
                ReportPropertyChanging("Text");
                _Text = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Text");
                OnTextChanged();
            }
        }
        private global::System.String _Text;
        partial void OnTextChanging(global::System.String value);
        partial void OnTextChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime CreatedAt
        {
            get
            {
                return _CreatedAt;
            }
            set
            {
                OnCreatedAtChanging(value);
                ReportPropertyChanging("CreatedAt");
                _CreatedAt = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreatedAt");
                OnCreatedAtChanged();
            }
        }
        private global::System.DateTime _CreatedAt;
        partial void OnCreatedAtChanging(global::System.DateTime value);
        partial void OnCreatedAtChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime UpdatedAt
        {
            get
            {
                return _UpdatedAt;
            }
            set
            {
                OnUpdatedAtChanging(value);
                ReportPropertyChanging("UpdatedAt");
                _UpdatedAt = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UpdatedAt");
                OnUpdatedAtChanged();
            }
        }
        private global::System.DateTime _UpdatedAt;
        partial void OnUpdatedAtChanging(global::System.DateTime value);
        partial void OnUpdatedAtChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="SMS_EMAIL_DB_Model", Name="tbl_Users")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tbl_Users : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new tbl_Users object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="user_Name">Initial value of the User_Name property.</param>
        /// <param name="password">Initial value of the Password property.</param>
        /// <param name="role">Initial value of the Role property.</param>
        /// <param name="status">Initial value of the Status property.</param>
        /// <param name="created_At">Initial value of the Created_At property.</param>
        /// <param name="updated_At">Initial value of the Updated_At property.</param>
        public static tbl_Users Createtbl_Users(global::System.Int32 id, global::System.String user_Name, global::System.String password, global::System.String role, global::System.String status, global::System.DateTime created_At, global::System.DateTime updated_At)
        {
            tbl_Users tbl_Users = new tbl_Users();
            tbl_Users.Id = id;
            tbl_Users.User_Name = user_Name;
            tbl_Users.Password = password;
            tbl_Users.Role = role;
            tbl_Users.Status = status;
            tbl_Users.Created_At = created_At;
            tbl_Users.Updated_At = updated_At;
            return tbl_Users;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String User_Name
        {
            get
            {
                return _User_Name;
            }
            set
            {
                OnUser_NameChanging(value);
                ReportPropertyChanging("User_Name");
                _User_Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("User_Name");
                OnUser_NameChanged();
            }
        }
        private global::System.String _User_Name;
        partial void OnUser_NameChanging(global::System.String value);
        partial void OnUser_NameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }
        private global::System.String _Password;
        partial void OnPasswordChanging(global::System.String value);
        partial void OnPasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Role
        {
            get
            {
                return _Role;
            }
            set
            {
                OnRoleChanging(value);
                ReportPropertyChanging("Role");
                _Role = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Role");
                OnRoleChanged();
            }
        }
        private global::System.String _Role;
        partial void OnRoleChanging(global::System.String value);
        partial void OnRoleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Status
        {
            get
            {
                return _Status;
            }
            set
            {
                OnStatusChanging(value);
                ReportPropertyChanging("Status");
                _Status = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Status");
                OnStatusChanged();
            }
        }
        private global::System.String _Status;
        partial void OnStatusChanging(global::System.String value);
        partial void OnStatusChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Sign_In_Count
        {
            get
            {
                return _Sign_In_Count;
            }
            set
            {
                OnSign_In_CountChanging(value);
                ReportPropertyChanging("Sign_In_Count");
                _Sign_In_Count = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Sign_In_Count");
                OnSign_In_CountChanged();
            }
        }
        private Nullable<global::System.Int32> _Sign_In_Count;
        partial void OnSign_In_CountChanging(Nullable<global::System.Int32> value);
        partial void OnSign_In_CountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> Last_Sign_In_At
        {
            get
            {
                return _Last_Sign_In_At;
            }
            set
            {
                OnLast_Sign_In_AtChanging(value);
                ReportPropertyChanging("Last_Sign_In_At");
                _Last_Sign_In_At = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Last_Sign_In_At");
                OnLast_Sign_In_AtChanged();
            }
        }
        private Nullable<global::System.DateTime> _Last_Sign_In_At;
        partial void OnLast_Sign_In_AtChanging(Nullable<global::System.DateTime> value);
        partial void OnLast_Sign_In_AtChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Created_At
        {
            get
            {
                return _Created_At;
            }
            set
            {
                OnCreated_AtChanging(value);
                ReportPropertyChanging("Created_At");
                _Created_At = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Created_At");
                OnCreated_AtChanged();
            }
        }
        private global::System.DateTime _Created_At;
        partial void OnCreated_AtChanging(global::System.DateTime value);
        partial void OnCreated_AtChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Updated_At
        {
            get
            {
                return _Updated_At;
            }
            set
            {
                OnUpdated_AtChanging(value);
                ReportPropertyChanging("Updated_At");
                _Updated_At = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Updated_At");
                OnUpdated_AtChanged();
            }
        }
        private global::System.DateTime _Updated_At;
        partial void OnUpdated_AtChanging(global::System.DateTime value);
        partial void OnUpdated_AtChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("SMS_EMAIL_DB_Model", "FK_tbl_Emails_tbl_Users", "tbl_Emails_SMS")]
        public EntityCollection<tbl_Emails_SMS> tbl_Emails_SMS
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<tbl_Emails_SMS>("SMS_EMAIL_DB_Model.FK_tbl_Emails_tbl_Users", "tbl_Emails_SMS");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<tbl_Emails_SMS>("SMS_EMAIL_DB_Model.FK_tbl_Emails_tbl_Users", "tbl_Emails_SMS", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
