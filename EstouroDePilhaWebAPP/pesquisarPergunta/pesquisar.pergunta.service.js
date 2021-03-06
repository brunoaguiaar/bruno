angular.module('EstouroPilhaApp').factory('pesquisarPerguntaService', function ($http){

  var urlPerguntas = "http://localhost:53986/api/perguntas/pesquisa";
  var urlNumeroderesultados = "http://localhost:53986/api/perguntas/numeroDeResultadosDaBusca";

  function buscarPerguntaPorTitulo(paginaAtual, conteudo, tags) {
    return $http.get(`${urlPerguntas}?skip=${encodeURIComponent(paginaAtual)}&conteudo=${encodeURIComponent(conteudo)}&tags=${encodeURIComponent(tags)}`);
  };

  function numeroDeResultadosDaPesquisa(conteudo, tags) {
    return $http.get(`${urlNumeroderesultados}?conteudo=${encodeURIComponent(conteudo)}&tags=${encodeURIComponent(tags)}`);
  };

  return {
    pesquisarTrazerResultados : buscarPerguntaPorTitulo,
    numeroDeResultadosDaPesquisa : numeroDeResultadosDaPesquisa
  }
});
