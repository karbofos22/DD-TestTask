using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DD_TestTask
{
    internal class SqlQuestions
    {
//
//        Ответ на задание 1:

//          Запрос 1: Сотрудник с максимальной заработной платой:

            //        SELECT*
            //        FROM Employee
            //        WHERE SALARY = (SELECT MAX(SALARY) FROM Employee)

//          Запрос 2: Максимальная длина цепочки руководителей по таблице сотрудников:

            //        WITH RECURSIVE ManagerHierarchy AS(
            //          SELECT ID, CHIEF_ID, 1 AS depth
            //          FROM Employee
            //          WHERE CHIEF_ID IS NULL
            //          UNION ALL
            //          SELECT e.ID, e.CHIEF_ID, mh.depth + 1
            //          FROM Employee e
            //          JOIN ManagerHierarchy mh ON e.CHIEF_ID = mh.ID
            //        )
            //          SELECT MAX(depth) as max_depth FROM ManagerHierarchy;

//          Запрос 3: Отдел с максимальной суммарной зарплатой сотрудников:

            //        SELECT d.NAME, SUM(e.SALARY) as total_salary
            //        FROM Employee e
            //        JOIN Department d ON e.DEPARTMENT_ID = d.ID
            //        GROUP BY d.NAME
            //        ORDER BY total_salary DESC
            //        FETCH FIRST 1 ROW ONLY;

//          Запрос 4: Сотрудник, чье имя начинается на «Р» и заканчивается на «н»:

            //        SELECT*
            //        FROM Employee
            //        WHERE NAME LIKE 'Р%н';


    }
}
