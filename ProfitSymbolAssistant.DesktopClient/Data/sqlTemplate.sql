--BEGIN SYMBOL {0}

DECLARE
	  @NewSymbolId INT
	, @NewSymbolDisplayName nvarchar(50) 
	, @SourceSymbolId INT
	, @Ask DECIMAL (18, 7)
	, @Bid DECIMAL (18, 7)

SELECT
     @NewSymbolDisplayName = '{0}'      -- Display Name of the new symbol
   , @SourceSymbolId = {1}     -- SymbolId of the old symbol to clone
   , @Ask = {2}
   , @Bid = {3}


SELECT
	@NewSymbolId = SymbolId
FROM [TradeNetworks].[Dealing].[Symbols]
WHERE
	[DisplayName] = @NewSymbolDisplayName

EXEC [TradeNetworks].[Integration].[AddSymbol]
	  @SourceSymbolId = @SourceSymbolId
	, @TargetSymbolId = @NewSymbolId
	, @Ask = @Ask
	, @Bid = @Bid
GO
	
--END SYMBOL {0}
