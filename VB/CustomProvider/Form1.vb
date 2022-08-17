Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraMap
Imports System.IO
Imports System.Drawing

Namespace CustomProvider

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            ' Create a map control, set its dock style and add it to the form.
            Dim map As MapControl = New MapControl()
            map.Dock = DockStyle.Fill
            Me.Controls.Add(map)
            ' Create a layer to load image tiles from a local map data provider.
            Dim imageTilesLayer As ImageTilesLayer = New ImageTilesLayer()
            map.Layers.Add(imageTilesLayer)
            imageTilesLayer.DataProvider = New LocalProvider()
        End Sub

        Public Class LocalProvider
            Inherits MapDataProviderBase

            Private ReadOnly projectionField As SphericalMercatorProjection = New SphericalMercatorProjection()

            Public Sub New()
                TileSource = New LocalTileSource(Me)
            End Sub

            Public Overrides ReadOnly Property Projection As IProjection
                Get
                    Return projectionField
                End Get
            End Property

            Public Overrides Function GetMapSizeInPixels(ByVal zoomLevel As Double) As MapSize
                Dim imageSize As Double
                imageSize = LocalTileSource.CalculateTotalImageSize(zoomLevel)
                Return New MapSize(imageSize, imageSize)
            End Function

            Protected Overrides ReadOnly Property BaseSizeInPixels As Size
                Get
                    Return New Size(Convert.ToInt32(LocalTileSource.tileSize * 2), Convert.ToInt32(LocalTileSource.tileSize * 2))
                End Get
            End Property
        End Class

        Public Class LocalTileSource
            Inherits MapTileSourceBase

            Public Const tileSize As Integer = 256

            Public Const maxZoomLevel As Integer = 1

            Friend Shared Function CalculateTotalImageSize(ByVal zoomLevel As Double) As Double
                If zoomLevel < 1.0 Then Return zoomLevel * tileSize * 2
                Return Math.Pow(2.0, zoomLevel) * tileSize
            End Function

            Public Sub New(ByVal cacheOptionsProvider As ICacheOptionsProvider)
                MyBase.New(512, 512, 256, 256, cacheOptionsProvider)
            End Sub

            Public Overrides Function GetTileByZoomLevel(ByVal zoomLevel As Integer, ByVal tilePositionX As Integer, ByVal tilePositionY As Integer) As Uri
                If zoomLevel = 1 Then Return New Uri(String.Format("file://" & Directory.GetCurrentDirectory() & "\tile_{0}_{1}_{2}.png", zoomLevel, tilePositionX, tilePositionY))
                Return Nothing
            End Function
        End Class
    End Class
End Namespace
