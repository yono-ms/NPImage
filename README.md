# NPImage
Xamarin Forms 9 patch image view.

## Overview
Xamarin Formsのアプリを作成する際に、
ほんの少しだけデザインをカスタマイズしたいことがあります。
例えばボタンのデザインです。
ネイティブでは適当な画像を何枚か用意して
状態毎に指定するだけです。
これがXamarin Formsではできません。
できないというのは語弊があります。
簡単にはできないというのが正しいです。


> When creating an Xamarin Forms application,
There are times when I want to customize the design a little.
For example the button design.
In native, prepare several suitable images
It is only specified for each state.
This can not be done with Xamarin Forms.
There is a word that we can not do.
It is correct that it can not be done easily.

そこで、
.NetStandardプロジェクトに置いた共通の画像ファイルを使用して、
3状態のデザイン切り替えを行うボタンを再利用化してみました。


> Therefore, we tried reusing buttons that switch designs in three states, using a common image file placed in the .NetStandard project.

- 拡大縮小しても歪まない
  > It does not distort even if it scales
- ボタンの状態で見た目が変わる
  > The appearance changes with the state of the button
- 用意する画像ファイルは最小限
  > Minimum image file to prepare

9-patchのpngファイルを前提にしているため、
ドット単位の美しさが必要なケースには向いていません。

> Because it is based on the 9-patch png file, it is not suitable for the case where the beauty of the dot unit is necessary.

## NPImageView class
Android向けに作成された9-patch形式のpngファイルを表示します。

### Step.1
Xamarin Formsの.NetStandardプロジェクトに、
***NuGetパッケージの管理***メニューで
**NPImage**を検索して追加します。

https://www.nuget.org/packages/NPImage/

### Step.2
埋め込みリソースを追加します。

> Add an embedded resource.

1. 9-patchのpngファイルを用意します。
1. Xamarin Formsのプロジェクトに既存の項目で追加します。
   今回の例ではResourcesフォルダの下に追加しています。
1. ファイルのプロパティで**ビルドアクション**を
   **埋め込みリソース**に設定します。

### Step.3
Xamarin FormsのContentPageに**xmlns**行を追加します。

```html:MainPage.xaml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:TestForms"
             xmlns:np="clr-namespace:NPImage;assembly=NPImage"
             x:Class="TestForms.MainPage">
```

表示したい場所にNPImageViewを配置します。

```html:MainPage.xaml
<np:NPImageView Source="TestForms.Resources.image.9.png"/>
```

**Source**パラメータはstring型のリソースIDです。
- アセンブリ（nemespace）
- フォルダ
- 埋め込みリソースファイル名

をドットで結合した文字列がリソースIDとなります。

## TSNPButton class
Android向けに作成された9-patch形式のpngファイルを背景に使用したボタンです。

- 通常時
- 押下時
- 非活性時

の3種類の状態で異なる画像を表示します。

### Step.1
前述の通りです。

### Step.2
前述の通りです。

ただし、今回は以下の3種類の画像を用意します。

- 通常時
- 押下時
- 非活性時

### Step.3
前述の通りです。

ただし、今回は以下の3種類の画像を設定します。

- 通常時
- 押下時
- 非活性時

```html:MainPage.xaml
<np:TSNPButton Text="custom" TextColor="White"
                Source="TestForms.Resources.red_default.9.png"
                SourcePressed="TestForms.Resources.red_pressed.9.png"
                SourceDisabled="TestForms.Resources.red_disabled.9.png"
                />
```
