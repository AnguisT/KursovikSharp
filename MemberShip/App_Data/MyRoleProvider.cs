using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MemberShip.Models;

public class MyRoleProvider : RoleProvider
{

    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
        throw new NotImplementedException();
    }
        
    public override string ApplicationName
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

    public override void CreateRole(string roleName)
    {
        throw new NotImplementedException();
    }

    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
        throw new NotImplementedException();
    }

    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
        throw new NotImplementedException();
    }

    public override string[] GetAllRoles()
    {
        throw new NotImplementedException();
    }

    public override string[] GetRolesForUser(string username)
    {
        string[] role = new string[] { };
        using (KursovikTP db = new KursovikTP())
        {
            try
            {
                // Получаем пользователя
                var user = (from u in db.People
                            where u.Login == username
                            select u).SingleOrDefault();
                if (user != null)
                {
                    // получаем роль
                    var userRole = (from r in db.Role
                                    where r.idRole == user.idRole
                                    select r).SingleOrDefault();

                    if (userRole != null)
                    {
                        role = new string[] { userRole.NameRole };
                    }
                }
            }
            catch
            {
                role = new string[] { };
            }
        }
        return role;
    }

    public override string[] GetUsersInRole(string roleName)
    {
        throw new NotImplementedException();
    }

    public override bool IsUserInRole(string username, string roleName)
    {
        bool outputResult = false;
        string[] namerole = roleName.Split(',');

        using (KursovikTP db = new KursovikTP())
        {
            foreach (var rn in namerole)
            {
                var user = (from u in db.People
                            where u.Login == username
                            select u).SingleOrDefault();
                if (user != null)
                {
                    var role = (from r in db.Role
                                where r.idRole == user.idRole
                                select r).SingleOrDefault();

                    if (role.NameRole.Equals(rn))
                    {
                        outputResult = true;
                    }
                }
            }
        }
        return outputResult;
    }

    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
        throw new NotImplementedException();
    }

    public override bool RoleExists(string roleName)
    {
        throw new NotImplementedException();
    }
}