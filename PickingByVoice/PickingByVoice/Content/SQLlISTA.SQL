SELECT distinct top 1000
	ListaSeparacao.NrLista,
	getdate() as dataImportacao,
	ListaSeparacao.Sequencia,
	'P' as status ,
	ListaSeparacao.CdProduto,
	ProArmazenagem.Descricao,
	ListaSeparacao.Tipo,
	ListaSeparacao.NumLote,
	'NULL' as cdmarca,
	'NULL' as dsMarca,
	ProArmazenagem.CdRefFab,
	'NULL' as cdfornecedor,
	'NULL' as nmFornecedor,
	ListaSeparacao.Quantidade,
	'NULL' as pesoliquido,
	'NULL' as pesoBruto,
	ListaSeparacao.DtValidade,
	ListaSeparacao.DtFabricacao,
	ListaSeparacao.CdEmbalagem,
	ListaSeparacao.SeqEmbalagem,
	ListaSeparacao.Tipo,
	ListaSeparacao.NrLista,
	'NULL' as nrpedido,
	'NULL' as dtlimite,
	'DESCRICAO ENDERECO' AS desendereco,
	'P' as status,
	getdate() as dtmanutencao,
	'USER' as usuario
FROM ListaSeparacao
	INNER JOIN ProArmazenagem ON ProArmazenagem.CdProduto = (SELECT TOP 1 CDPRODUTO FROM ProArmazenagem WHERE CdProduto = ListaSeparacao.CdProduto )
ORDER BY ListaSeparacao.NrLista DESC, Sequencia

