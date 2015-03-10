﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Text;

// External Library
using RestSharp;
using Newtonsoft.Json;

using TDSPRINT.Cloud.SDK.Datas;
using TDSPRINT.Cloud.SDK.Types;

namespace TDSPRINT.Cloud.SDK
{
    public class UserClient : TSCloud
    {
        #region constructor
        public UserClient()
        {
        }
        public UserClient(TSCloud TSCloud) : this()
        {
            Hostname = TSCloud.Hostname;
            RestClient = new RestClient(Hostname);
            ApiToken = TSCloud.ApiToken;
            CurrentUser = TSCloud.CurrentUser;
        }
        #endregion
        #region public method
        public Users All()
        {
            RestRequest request = new RestRequest(String.Format("{0}/users", ApiPath), Method.GET);
            request.AddParameter("api_token", ApiToken);

            try
            {
                IRestResponse httpResponse = RestClient.Execute(request);
                List<User> user_list = JsonConvert.DeserializeObject<List<User>>(httpResponse.Content, TSCloud.serializer_settings());

                return new Users(user_list);
            }
            catch
            {
                return new Users();
            }
        }
        public User Create(User user)
        {
            if(String.IsNullOrEmpty(user.Email))
                throw new Exception("Email required");

            RestRequest request = new RestRequest(String.Format("{0}/users", ApiPath), Method.POST);
            request.AddParameter("api_token", ApiToken);
            request.AddParameter("email", user.Email);
            request.AddParameter("password", user.Password);
            request.AddParameter("name", user.Name);
            request.AddParameter("phone", user.Phone);
            request.AddParameter("address", user.Address);
            request.AddParameter("company", user.Company);
            request.AddParameter("role", user.Role);
            request.AddParameter("meta", user.Meta.Stringify());

            try
            {
                IRestResponse httpResponse = RestClient.Execute(request);
                User created_user = JsonConvert.DeserializeObject<User>(httpResponse.Content, TSCloud.serializer_settings());

                return created_user;
            }
            catch(Exception ee)
            {
                return new User(Convert.ToString(ee));
            }
        }

        #endregion

        #region private method
        //private string get_acl()
        //{
        //    Acl AclObject = new Acl(Int32.Parse(CurrentUser.Id.ToString()));
        //    return JsonConvert.SerializeObject(AclObject, Formatting.None);
        //}
        #endregion
    }
}
