using AdventureWorksDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : Controller
    {
        
        //Person tablosundaki FistName=Kevin isminin olduğu bütün elemanları gösteriyor
        
        private const string CONNECTION_STRING = "Server=NIRVANA\\SQLEXPRESS;Database=AdventureWorks2017;Trusted_Connection=True;";
          [HttpGet("")]
          public async Task<IActionResult> SelectInQuery([FromQuery] bool getKevins)
          {
              var sql = @"SELECT 

                      [Title]
                     ,[FirstName]
                     ,[MiddleName]
                     ,[LastName]

                    FROM [Person].[Person]";
              var dynamicParameters = new DynamicParameters();
              if (getKevins)
              {
                  sql += "WHERE FirstName=@firstName";
                  dynamicParameters.Add("firstName", "Kevin");
              }

              using (var connection = new SqlConnection(CONNECTION_STRING))
              {
                  var persons = await connection.QueryAsync<Person>(sql, dynamicParameters); ;
                  return Ok(persons);

              }

          }
          //transactional 
          //KevinsTestTable oluşturuluyor ve tablonun içine id ve foobarları ekliyor
          [HttpGet("")]
          public async Task<IActionResult> Index([FromQuery] bool getKevins)
          {
              var sql = @"INSERT INTO [dbo].[KevinsTestTable]
                        ([Foobar])
                        VALUES
                        (@foobar)";
              using (var connection = new SqlConnection(CONNECTION_STRING))
              {
                  await connection.OpenAsync();
                  using (var transaction = connection.BeginTransaction())
                  {
                      for (var x = 0; x < 10000; x++)
                      {

                          await connection.ExecuteAsync(sql,
                              new { foobar = $"testing{DateTime.UtcNow.Ticks}" },
                              transaction:transaction);
                      }
                      transaction.Commit();

                  }
              }
              return Ok();
          }
        //transactional
        //JohnsTestTable oluşturuluyor ve tablonun içine id ve foobarları ekliyor
        [HttpGet("")]
          public async Task<IActionResult> Index2([FromQuery] bool getMelike)
          {
              var sql = @"INSERT INTO [dbo].[JohnsTestTable]
                        ([Foobar])
                        VALUES
                        (@foobar)";
              using (var connection = new SqlConnection(CONNECTION_STRING))
              {
                  await connection.OpenAsync();
                  using (var transaction = connection.BeginTransaction())
                  {
                      for (var x = 0; x < 10000; x++)
                      {

                          await connection.ExecuteAsync(sql,
                              new { foobar = $"testing{DateTime.UtcNow.Ticks}" },
                              transaction: transaction);
                      }
                      transaction.Commit();

                  }
              }
              return Ok();
          }
           
        
        //INSERT
        //ekleme işlemi yapılıyor
        [HttpPost("")]
        private static async Task DemoExecuteAsyncWithInsert(Person model)
        {
            await using var connection = new SqlConnection(CONNECTION_STRING);
            var sql = @"
                 INSERT INTO[Person].[Person]
                (
                  ,[Title]
                  ,[FirstName]
                  ,[MiddleName]
                  ,[LastName]
                 VALUES
                ( @BusinessEntityID
                , @Title
                , @FirstName
                , @MiddleName
                , @LastName )";

            var affected = await connection.ExecuteAsync(sql, new
            {
                Title = "Ms",
                FirstName = "Melike",
                MiddleName = "Yok",
                LastName = "Sertkaya",
            });
          

        }

       //UPDATE
       //Last name i güncelliyor
        [HttpPut("{lastName}")]
        public async Task<IActionResult> Put(string lastName, [FromBody] Person model)
        {
            if (lastName != model.LastName)
            {
                return BadRequest();
            }

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                await connection.OpenAsync();
                var sqlStatement = @"
                UPDATE[Person].[Person]
                SET [BusinessEntityID] = @BusinessEntityID
               ,[Title] = @Title
               ,[FirstName] = @FirstName
               ,[MiddleName] = @MiddleName
               ,[LastName] = @LastName
               WHERE LastName =@LastName";

                await connection.ExecuteAsync(sqlStatement, model);
            }
            return Ok();
        }

        //DELETE
        [HttpDelete("{businessEntityID}")]
        public async Task<IActionResult> Delete(int businessEntityID)
        {

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                await connection.OpenAsync();
                var sqlStatement = "DELETE Person WHERE BusinessEntityID = @BusinessEntityID";
                await connection.ExecuteAsync(sqlStatement, new { BusinessEntityID = businessEntityID });
            }
            return Ok();
        }

        [HttpDelete("{MiddleName}")]
        public async Task<IActionResult> DeleteInQuery(string middleName, [FromBody] Person model)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                await connection.OpenAsync();
                var sqlStatement = @"
               DELETE FROM [Person].[Person]
               WHERE MiddleName=@MiddleName";
                await connection.QueryAsync(sqlStatement, new { MiddleName = middleName });
            }
            return Ok();

        }
        
        //Sp Kullanıldı
        [HttpGet]
        public async Task<IEnumerable<Person>> Get(string model)
        {
            IEnumerable<Person> person;

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                await connection.OpenAsync();

                person = await connection.QueryAsync<Person>("GetPersonModel",
                                new { Model = model },
                                commandType: CommandType.StoredProcedure);
            }
            return person;
        }

        //  one to one
        //Employye modelindeki id ile Sales Person daki id eşleniyor ve employee deki sırayı takip ediyor( Sp.TerritoryID)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactAsync(int id)
        {

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                await connection.OpenAsync();
                var query = @"SELECT
                e.BusinessEntityID, e.LoginID, e.JobTitle,
				Sp.BusinessEntityID, Sp.TerritoryID
				from Employee e,
				SalesPerson Sp
				where e.BusinessEntityID = Sp.TerritoryID
				and e.id = @id";

                var employee = await connection.QueryAsync<Employee>(query, new { @id = id });
                return Ok(employee);
            }

        }

        private static Employee Deneme(Employee employee, SalesPerson salesPerson)
        {
            employee.SalesPerson = salesPerson;
            return employee;
        }

        //One to Many
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizationAsync(int id)
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                await connection.OpenAsync();
                
                var query = @"SELECT* from Persons where id = @id;
				Select * from Employees where BusinessEntityID = @id";

                var results = await connection.QueryMultipleAsync(query, new { @id = id });

                //sonuclar ilgili modellerden alınıyor
                var org = results.ReadSingle<Person>();
                org.Employees = results.Read<Employee>().ToList();

                return Ok(org);
            }
        }

    }
}
