﻿/****************************** 模块头 ******************************\
* 模块名:	IndependentAssociationClass.cs
* 项目:		CSEFForeignKeyAssociation
* Copyright (c) Microsoft Corporation.
* 
* 这个文件展示了怎样插入新的关系实体，利用Independent Association来插入已存在实体和更新已存在实体。
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

#region Using directive
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace CSEFForeignKeyAssociation.IndependentAssociation
{
    public class IndependentAssociationClass
    {
        /// <summary>
        /// 测试Independent Association的插入和更新方法。
        /// </summary>
        public static void Test()
        {
            Console.WriteLine("Independent Association下插入一条新的Course和Department关联实体...");

            // Independent Association插入新的关联实体。
            InsertNewRelatedEntities();

            // 查询数据库。
            Query();

            Console.WriteLine("Independent Association下插入一条新的Course并将其关联到一个已存在的Department实体...");

            // Independent Association下插入一个新实体并关联到已存在实体。
            InsertByExistingEntities();

            // 查询数据库。
            Query();

            Console.WriteLine("更新一个已存在的Course实体和与它关联的Department实体" + 
                "(只有常规属性)...");

            Course course = null;
            using (IndependentAssociationEntities context = 
                new IndependentAssociationEntities())
            {
                // 获取一个已存在的Course实体。
                // 注意： 此方法是EF 4.0中的新方法。
                course = context.Courses.Single(c => c.CourseID == 5002);

                // 修改Course实体的Title属性。
                course.Title = "Data Structures";

                // 在Independent Association条件下设置关系。
                course.Department = context.Departments.Single(
                    d => d.DepartmentID == 5);
            }

            // 更新一个已存在的Course实体。
            UpdateExistingEntities(course);

            // 查询数据库。
            Query();
        }


        /// <summary>
        /// Independent Association下插入一条新的Course和Department关联实体
        /// </summary>
        private static void InsertNewRelatedEntities()
        {
            using (IndependentAssociationEntities context = 
                new IndependentAssociationEntities())
            {
                // 创建一个新的Department实体。
                Department department = new Department()
                {
                    DepartmentID = 6,
                    Name = "Software Engineering",
                    Budget = 300000,
                    StartDate = DateTime.Now
                };

                // 创建一个新的Course实体。
                Course course = new Course()
                {
                    CourseID = 6001,
                    Title = "Object Oriented",
                    Credits = 4,
                    StatusID = true,
                    // 设置导航属性。
                    Department = department
                };

                try
                {
                    // 注意： 只需要添加一个实体，因为关系和关联实体将自动被添加。
                    context.AddToCourses(course);

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        /// <summary>
        /// Independent Association下插入一条新的Course并将其设置成附属于一个已存在的Department。
        /// </summary>
        private static void InsertByExistingEntities()
        {
            using (IndependentAssociationEntities context = 
                new IndependentAssociationEntities())
            {
                // 创建一个新的Course实体。
                Course course = new Course()
                {
                    CourseID = 6002,
                    Title = ".NET Framework",
                    Credits = 4,
                    StatusID = true,
                    // 设置导航属性为已存在的Department实体
                    Department = context.Departments.Single(
                        d => d.DepartmentID == 6)
                };

                try
                {
                    // 注意： 不需要将Course实体添加进ObjectContext，因为它
                    // 被自动关联到了一个已存在的Department实体。
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        /// <summary>
        /// 更新一个已存在的Course实体（只有常规属性，不包括关系）
        /// </summary>
        /// <param name="updatedCourse">一个已存在的Course实体和更新的数据</param>
        private static void UpdateExistingEntities(Course updatedCourse)
        {
            using (IndependentAssociationEntities context = 
                new IndependentAssociationEntities())
            {
                try
                {
                    // 查询数据库来获取要更新的实体
                    var originalCourse = context.Courses.SingleOrDefault(
                        c => c.CourseID == updatedCourse.CourseID);

                    /////////////////////////////////////////////////////////
                    // 使用ApplyCurrentValues API来更新实体
                    // 
                    // 在EFv1时代，EFv1中的ApplyPropertyChanges方法能够使用其他实体的值来更新一个实体。
                    // 在EF4时代，此方法更名为ApplyCurrentValues，此方法打算用来更新一个实体的当前值，
                    // 假定是刚从数据库提取的实体。这将会允许SaveChanges方法创建适当的命令来将那些新数据
                    // 更新到实体。 

                    // 适用于最新的Course实体包括外键属性的原始值。
                    // 注意： 在这里，导航属性就算被更改了也不会被更新。
                    if (originalCourse != null)
                    {
                        context.Courses.ApplyCurrentValues(updatedCourse);
                    }

                    // 保存更改。
                    context.SaveChanges();


                    /*
                    /////////////////////////////////////////////////////////
                    // 使用ApplyOriginalValues API来更新实体
                    // 
                    // ApplyOriginalValues假设所被追踪的实体已经拥有需要被更新到数据库的数据，而非实体的原始数据。
                    // 这是为n层应用程序设计的。通过在拥有新数据的实体上调用Attach方法，实体将自动变为Unchanged状态，
                    // 并且拥有相应匹配的当前值和过去值。ApplyOriginalValues帮助我们通过分离实体来使用实体的原始值。
                     
                    // 为了展示ApplyOriginalValues，我们首先分离原始的Course实体。
                    context.Detach(originalCourse);

                    // 附加一个新的更新的Course实体
                    context.Courses.Attach(updatedCourse);

                    // 适用于最新的Course实体包括外键属性的原始值。
                    // 注意： 在这里，导航属性就算被更改了也不会被更新。
                    context.Courses.ApplyOriginalValues(originalCourse);

                    // 保存更改。
                    context.SaveChanges();
                    */
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }      
        }


        /// <summary>
        /// 查询Course实体和对应的Department实体。
        /// </summary>
        private static void Query()
        {
            using (IndependentAssociationEntities context = 
                new IndependentAssociationEntities())
            {
                foreach (var c in context.Courses)
                {
                    Console.WriteLine("Course ID:{0}\nTitle:{1}\n" +
                        "Department:{2}", c.CourseID, c.Title,
                        c.Department.Name);
                }
            }

            Console.WriteLine();
        }
    }
}
