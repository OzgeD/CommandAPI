using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Models;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;

        public CommandsController(CommandContext context)
        {
            _context = context ;
        }

        /// <summary>
        /// Get all commands
        /// </summary>
        /// <returns></returns>
        //GET:      api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetCommandItems()
        {
            return _context.CommandItems;
        }

        /// <summary>
        /// Get commands by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //GET:      api/commands/n
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandItem(int id)
        {
            var commandItem = _context.CommandItems.Find(id);
            if(commandItem ==null)
            {
                return NotFound();
            }
            return commandItem;
        }

        /// <summary>
        /// Create a command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        //POST:     api/commands
        [HttpPost]
        public ActionResult<Command> PostCommandItem(Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();

            return CreatedAtAction("GetCommandItem", new Command{Id = command.Id}, command);
        }

        /*public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "this", "is", "hard", "coded" };
        }*/
    }
}
