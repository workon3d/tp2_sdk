﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TDSPRINT.Cloud.SDK.Types;
using Newtonsoft.Json;

namespace TDSPRINT.Cloud.SDK.Datas
{
    public class Models
    {
        public object parent;
        public List<Model> contents;
        public Pagination pagination;
    }

    public class Model
    {
        #region member variable
        private int m_id;
        private bool m_readonly;
        private string m_name;
        private int m_size;
        private string m_key;
        private object m_meta;
        private object m_ancestry;
        private Ftype m_ftype;
        private object m_acl;
        private string m_api_url;
        private object m_preview;
        private string m_description;
        private string m_created_at;
        private string m_updated_at;
        private string m_message;
        private HttpStatusCode m_StatusCode;
        #endregion

        #region constructor
        public Model(HttpStatusCode status_code, string strMessage = null)
        {
            Message = strMessage;
            StatusCode = status_code;
        }
        public Model(string strMessage)
        {
            Message = strMessage;
        }
        public Model()
        {
        }
        #endregion

        #region getter/setter
        [JsonProperty("id")]
        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }
        [JsonProperty("name")]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        [JsonProperty("size")]
        public object SetSize
        {
            set {
                try
                {
                    m_size = Convert.ToInt32(value);
                }
                catch
                {
                    m_size = 0;
                }
            }
        }
        public int Size
        {
            get { return m_size; }
        }
        [JsonProperty("meta")]
        public object Meta
        {
            get { return m_meta; }
            set { m_meta = value; }
        }
        [JsonProperty("key")]
        public string Key
        {
            get { return m_key; }
            set { m_key = value; }
        }
        [JsonProperty("ancestry")]
        public object Ancestry
        {
            get { return m_ancestry; }
            set { m_ancestry = value; }
        }
        [JsonProperty("ftype")]
        public Ftype Ftype
        {
            get { return m_ftype; }
            set { m_ftype = value; }
        }
        [JsonProperty("acl")]
        public object Acl
        {
            get { return m_acl; }
            set { m_acl = value; }
        }
        [JsonProperty("api_url")]
        public string ApiUrl
        {
            get { return m_api_url; }
            set { m_api_url = value; }
        }
        [JsonProperty("preview")]
        public object Preview
        {
            get { return m_preview; }
            set { m_preview = value; }
        }
        [JsonProperty("description")]
        public string Description
        {
            get { return m_description; }
            set { m_description = value; }
        }
        [JsonProperty("created_at")]
        public string CreatedAt
        {
            get { return m_created_at; }
            set { m_created_at = value; }
        }
        [JsonProperty("updated_at")]
        public string UpdatedAt
        {
            get { return m_updated_at; }
            set { m_updated_at = value; }
        }
        public string Message
        {
            get { return m_message; }
            set { m_message = value; }
        }
        public HttpStatusCode StatusCode
        {
            get { return m_StatusCode; }
            set { m_StatusCode = value; }
        }
        [JsonProperty("readonly")]
        public bool Readonly
        {
            get { return m_readonly; }
            set
            {
                try
                {
                    m_readonly = value;
                }
                catch
                {
                    m_readonly = false;
                }
            }
        }
        #endregion
        
        #region static method
        static public bool IsValid(Model model)
        {
            try
            {
                if (model.Id == 0 || String.IsNullOrEmpty(model.Key) || String.IsNullOrEmpty(model.Acl.ToString()))
                    return false;
                else
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public bool IsValid()
        {
            return Model.IsValid(this);
        }
        #endregion
    }

    public class Meta
    {
        public string Key;
        public string Value;

        public Meta()
        {
        }

        public Meta(string strKey, string strValue)
        {
            Key = strKey;
            Value = strValue;
        }
    }
    
    public class Pagination
    {
        public int total;
        public object per_page;
        public object num_pages;
        public object current_page;
        public object prev_page;
        public object next_page;
    }
}
