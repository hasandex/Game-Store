using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Models
{
    public class GameDevice
    {
        [ForeignKey("game")]
        public int gameId {  get; set; }
        public Game? game { get; set; }

        [ForeignKey("device")]
        public int deviceId {  get; set; }
        public Device? device { get; set; }
    }
}
