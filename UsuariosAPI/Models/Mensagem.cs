using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosAPI.Models
{
    public class Mensagem
    {
        

        public List<MailboxAddress> Destinatarios { get; set; }
        public string Assunto { get; set; }
        public string Conteudo { get; set; }
        

        public Mensagem(Dictionary<string, string> destinatarios, string assunto, int usuarioId, string codigoAtivacao)
        {
            Destinatarios = new List<MailboxAddress>();
            Destinatarios.AddRange(destinatarios.Select(d => new MailboxAddress(d.Key, d.Value)));
            Assunto = assunto;
            Conteudo = $"https://campeonatobrasileiroauthenticationapi.azure-api.net/cadastros/ativa?usuarioId={usuarioId}&CodigoAtivacao={codigoAtivacao}";
        }
    }
}
