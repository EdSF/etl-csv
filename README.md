# ETL: Uneven Delimited Data

#### Exercise: Convert an unevenly distributed (uneven columns) CSV file to JSON

- File: `input.csv`
- Specification:

   - CSV file has one `File` record, designated "`F`" and one `End` record, designated "`E`"
   - Each `F` record can contain multiple `Order` records, designated "`O`" (*_see notes on `Order` designation_)
   - Each `O` record contains a single `B`, `S` & `M` & `T` records (*_see notes on `Order` designation_)
   - Each `O` record can contain multiple `Line Item` records, designated "`L`" (*_see notes on `Order` designation_)
   

**Notes**: 

- _While the definition above states that an `Order` is designated with an `O`, the file itself (`input.csv`) uses `H` for it's designation and is being treated as a typographical error, otherwise the file is "invalid" based on specification_
- _No "schema" is provided. Field names have been created based on interpretations and/or assumptions given the data_

````
"F","08/04/2016"," By Batch #"
"H","S","08/04/2016","ONF002793300","08/04/2016","080427bd1","","ONF",""
"B","Brett Nagy","5825 221st Place S.E.","Suite 205","Issaquah","WA","98027","","UNITED STATES","(425) 392-7432","","example@microgroove.com","??","0000","","",""
"S","Brett Nagy","5825 221st Place S.E.","Suite 205","Issaquah","WA","98027","","UNITED STATES","(425) 392-7432",""
"M","S","Thank you for purchasing from our storefront."
"L","602527788265","02","ISLB001604302.2","1","1","0","0","0","2039","2039","602527788265","15955753","0","0"
"L","602517642850","01","ISLB001095001.1","2","2","0","0","0","1898","3796","602517642850","13486891","0","0"
"T","3","3","0","2","0","0","0","0","0","08890049","PLS07414521","050","124545454545454545454","0","08/04/2016","","","5835","0","0","1385","7220"
"E","1","2","9"
````

#### Sample Output Files

- Original `File` record containing 1 `Order` :[csv-to-json-single-order.json](https://github.com/EdSF/etl-csv/blob/master/DelimitedFileParsing/SampleOutput/csv-to-json-single-order.json)
- `File` record containing 2 `Orders`: [csv-to-json-multi-order.json](https://github.com/EdSF/etl-csv/blob/master/DelimitedFileParsing/SampleOutput/csv-to-json-multi-order.json)

#### Dependencies

- JSON.Net
