﻿using System.Linq;
using CommandPrompterServer.Models.Dao;
using System.Collections.Generic;
using System;
using CommandPrompterServer.Models.Dto;

namespace CommandPrompterServer.Managers
{
    public class UserManagerImpl : BaseManagerImpl<User>, IUserManager
    {
        /// <summary>
        /// User need add the RegisterTime, so it's been overridden here. Only Username, password, email are required.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override User AddNewEntity(User entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.RegisterTime = DateTime.Now;
            entity.Deactivated = false;
            entity.DeactivatedTime = null;
            entity.LastLoginTime = null;
            entity.Contributes = 0;
            context.Users.Add(entity);
            return entity;
        }
        public void ActivateUser(string id)
        {
            var ret = from user in context.Set<User>() where user.Id == id && user.Deactivated == true select user;
            if(ret != null && ret.Count() != 0)
            {
                ret.FirstOrDefault().Deactivated = false;
                ret.FirstOrDefault().DeactivatedTime = null;
                context.Users.Update(ret.FirstOrDefault());
            }
        }

        public void DeactivateUser(string id)
        {
            var ret = from user in context.Set<User>() where user.Id == id && user.Deactivated == false select user;
            if (ret != null && ret.Count() != 0)
            {
                ret.FirstOrDefault().Deactivated = true;
                ret.FirstOrDefault().DeactivatedTime = DateTime.Now;
                context.Users.Update(ret.FirstOrDefault());
            }
        }

        public List<User> GetAllActivatedUsers()
        {
            var ret = from user in context.Set<User>() where user.Deactivated == false select user;
            if(ret != null && ret.Count() != 0)
            {
                return ret.ToList<User>();
            }
            return null;
        }

        public void UpdateLastLoginTime(string id)
        {
            var ret = from user in context.Set<User>() where user.Id == id && user.Deactivated == false select user;
            if (ret != null && ret.Count() != 0)
            {
                ret.FirstOrDefault().LastLoginTime = DateTime.Now;
                context.Users.Update(ret.FirstOrDefault());
            }
        }

        public User ValidateUserInfo(string username, string password)
        {
            var ret = from user in context.Set<User>() where user.Deactivated == false && user.Username == username && user.Password == password select user;
            if (ret != null && ret.Count() != 0)
                return ret.FirstOrDefault<User>();
            return null;

        }

        public List<RelatedNameResponseDto> Search(string name)
        {
            var ret = from user in context.Set<User>() where user.Username.Contains(name) select user;
            if (ret != null && ret.Count() != 0)
            {
                var list = new List<RelatedNameResponseDto>();
                foreach(var item in ret)
                {
                    list.Add(new RelatedNameResponseDto()
                    {
                        Id = item.Id,
                        Name = item.Username,
                        Type = "User"
                    });
                }
                return list;
            }
            return null;
        }
    }
}
