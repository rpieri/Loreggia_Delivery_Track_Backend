namespace Loreggia.Delivery.Track.Autenticador.ReadOnlyRepository.Queries
{
    public static class UsuarioQueries
    {
        public static readonly string ListaUsuario = @"SELECT
                                                          usuario.codigo,
                                                          usuario.nome,
                                                          usuario.email
                                                       FROM usuario
                                                       WHERE usuario.apagado = 'FALSE'";

        public static readonly string BuscarUsuario = @"SELECT
                                                            usuario.codigo,
                                                            usuario.codigo_empresa AS codigoEmpresa,
                                                            usuario.nome,
                                                            usuario.email,
                                                            usuario.senha
                                                        FROM usuario
                                                        WHERE usuario.apagado = 'FALSE'
                                                            AND usuario.codigo = @codigo";
    }
}
