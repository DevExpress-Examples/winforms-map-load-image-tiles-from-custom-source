# How to load image tiles from another source by creating custom data provider


<p>This example illustrates how to implement a custom provider of image tiles. For this it's necessary to create a <a href="http://help.devexpress.com/#WindowsForms/clsDevExpressXtraMapMapDataProviderBasetopic"><u>MapDataProviderBase</u></a> class descendant and assign it to the <strong>ImageTilesLayer.DataProvider</strong> property.</p>
<p>The sample below shows how to load image tiles from a local cache. It might be possible only if you previously downloaded a bulk of image tiles from one of the available image tile providers. For example, a list of alternative OpenStreetMap image tile providers is available here: <a href="http://wiki.openstreetmap.org/wiki/Tile_usage_policy#Alternative_OpenStreetMap_Tile_Providers">OpenStreetMap: Tile usage policy</a>.</p>
<p><strong>Note:</strong> If you don't need to create a custom data provider and only require changing the Uri to the location of image tiles, use the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapOpenStreetMapDataProvider_TileUriTemplatetopic">OpenStreetMapDataProvider.TileUriTemplate</a> property.</p>

<br/>


