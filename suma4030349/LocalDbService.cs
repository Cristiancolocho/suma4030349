using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace suma4030349
{
    public class LocalDbService
    {
        private const string DB_NAME = "demo_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));

            //Le indica al sistema que crea la tabla de nuestro contexto

            _connection.CreateTableAsync<Resultado>();
        }

        //Listar registros de nuestra tabla
        public async Task<List<Resultado>> GetResultado()
        {
            return await _connection.Table<Resultado>().ToListAsync();
        }

        public async Task<Resultado> GetById(int id)
        {
            return await _connection.Table<Resultado>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        //Metodo para crear registro
        public async Task Create(Resultado resultado)
        {
            await _connection.InsertAsync(resultado);
        }

        //Actualizar
        public async Task Update(Resultado resultado)
        {
            await _connection.UpdateAsync(resultado);
        }

        //Eliminar
        public async Task Delete(Resultado resultado)
        {
            await _connection.DeleteAsync(resultado);
        }
    }
}
