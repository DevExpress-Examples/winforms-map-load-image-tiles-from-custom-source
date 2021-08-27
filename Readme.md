<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128576605/13.1.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4758)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/CustomProvider/Form1.cs) (VB: [Form1.vb](./VB/CustomProvider/Form1.vb))
<!-- default file list end -->
# How to load image tiles from another source by creating custom data provider


<p>This example illustrates how to implement a custom provider of image tiles. For this it's necessary to create a <a href="http://help.devexpress.com/#WindowsForms/clsDevExpressXtraMapMapDataProviderBasetopic"><u>MapDataProviderBase</u></a> class descendant and assign it to the <strong>ImageTilesLayer.DataProvider</strong> property.</p>
<p>The sample below shows how to load image tiles from a local cache. It might be possible only if you previously downloaded a bulk of image tiles from one of the available image tile providers. For example, a list of alternative OpenStreetMap image tile providers is available here: <a href="http://wiki.openstreetmap.org/wiki/Tile_usage_policy#Alternative_OpenStreetMap_Tile_Providers">OpenStreetMap: Tile usage policy</a>.</p>
<p><strong>Note:</strong> If you don't need to create a custom data provider and only require changing the Uri to the location of image tiles, use the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapOpenStreetMapDataProvider_TileUriTemplatetopic">OpenStreetMapDataProvider.TileUriTemplate</a> property.</p>


<h3>Description</h3>

<p>In this example a custom MapTileSourceBase class is implemented to get local tiles from tile images stored in the local cache. </p>

<br/>


