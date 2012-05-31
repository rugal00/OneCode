﻿/********************************* 模块头 **********************************\
模块名:    Person.cs
项目:      CSSL4DataGridGroupHeaderStyle
Copyright (c) Microsoft Corporation.

定义 Person 实体.

This source is subject to the Microsoft Public License.
See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
All other rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System.Collections.Generic;

namespace CSSL4DataGridGroupHeaderStyle
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string AgeGroup { get; set; }
    }
    public class People
    {
        public static List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();
            people.Add(new Person() { FirstName = "Tom", LastName = "Smith", Gender = "M", AgeGroup = "成人" });
            people.Add(new Person() { FirstName = "Emma", LastName = "Smith", Gender = "F", AgeGroup = "成人" });
            people.Add(new Person() { FirstName = "Jacob", LastName = "Smith", Gender = "M", AgeGroup = "成人" });
            people.Add(new Person() { FirstName = "Joshua", LastName = "Smith", Gender = "M", AgeGroup = "儿童" });
            people.Add(new Person() { FirstName = "Michael", LastName = "Smith", Gender = "M", AgeGroup = "儿童" });
            people.Add(new Person() { FirstName = "Emily", LastName = "Smith", Gender = "F", AgeGroup = "儿童" });
            return people;
        }
    } 
}
