# NPImage
Xamarin Forms 9 patch image view.

## Overview
Xamarin Forms�̃A�v�����쐬����ۂɁA
�ق�̏��������f�U�C�����J�X�^�}�C�Y���������Ƃ�����܂��B
�Ⴆ�΃{�^���̃f�U�C���ł��B
�l�C�e�B�u�ł͓K���ȉ摜���������p�ӂ���
��Ԗ��Ɏw�肷�邾���ł��B
���ꂪXamarin Forms�ł͂ł��܂���B
�ł��Ȃ��Ƃ����̂͌ꕾ������܂��B
�ȒP�ɂ͂ł��Ȃ��Ƃ����̂��������ł��B


> When creating an Xamarin Forms application,
There are times when I want to customize the design a little.
For example the button design.
In native, prepare several suitable images
It is only specified for each state.
This can not be done with Xamarin Forms.
There is a word that we can not do.
It is correct that it can not be done easily.

�����ŁA
.NetStandard�v���W�F�N�g�ɒu�������ʂ̉摜�t�@�C�����g�p���āA
3��Ԃ̃f�U�C���؂�ւ����s���{�^�����ė��p�����Ă݂܂����B


> Therefore, we tried reusing buttons that switch designs in three states, using a common image file placed in the .NetStandard project.

- �g��k�����Ă��c�܂Ȃ�
  > It does not distort even if it scales
- �{�^���̏�ԂŌ����ڂ��ς��
  > The appearance changes with the state of the button
- �p�ӂ���摜�t�@�C���͍ŏ���
  > Minimum image file to prepare

9-patch��png�t�@�C����O��ɂ��Ă��邽�߁A
�h�b�g�P�ʂ̔��������K�v�ȃP�[�X�ɂ͌����Ă��܂���B

> Because it is based on the 9-patch png file, it is not suitable for the case where the beauty of the dot unit is necessary.

## NPImageView class
Android�����ɍ쐬���ꂽ9-patch�`����png�t�@�C����\�����܂��B

### Step.1
Xamarin Forms��.NetStandard�v���W�F�N�g�ɁA
***NuGet�p�b�P�[�W�̊Ǘ�***���j���[��
**NPImage**���������Ēǉ����܂��B

https://www.nuget.org/packages/NPImage/

### Step.2
���ߍ��݃��\�[�X��ǉ����܂��B

> Add an embedded resource.

1. 9-patch��png�t�@�C����p�ӂ��܂��B
1. Xamarin Forms�̃v���W�F�N�g�Ɋ����̍��ڂŒǉ����܂��B
   ����̗�ł�Resources�t�H���_�̉��ɒǉ����Ă��܂��B
1. �t�@�C���̃v���p�e�B��**�r���h�A�N�V����**��
   **���ߍ��݃��\�[�X**�ɐݒ肵�܂��B

### Step.3
Xamarin Forms��ContentPage��**xmlns**�s��ǉ����܂��B

```html:MainPage.xaml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:TestForms"
             xmlns:np="clr-namespace:NPImage;assembly=NPImage"
             x:Class="TestForms.MainPage">
```

�\���������ꏊ��NPImageView��z�u���܂��B

```html:MainPage.xaml
<np:NPImageView Source="TestForms.Resources.image.9.png"/>
```

**Source**�p�����[�^��string�^�̃��\�[�XID�ł��B
- �A�Z���u���inemespace�j
- �t�H���_
- ���ߍ��݃��\�[�X�t�@�C����

���h�b�g�Ō������������񂪃��\�[�XID�ƂȂ�܂��B

## TSNPButton class
Android�����ɍ쐬���ꂽ9-patch�`����png�t�@�C����w�i�Ɏg�p�����{�^���ł��B

- �ʏ펞
- ������
- �񊈐���

��3��ނ̏�ԂňقȂ�摜��\�����܂��B

### Step.1
�O�q�̒ʂ�ł��B

### Step.2
�O�q�̒ʂ�ł��B

�������A����͈ȉ���3��ނ̉摜��p�ӂ��܂��B

- �ʏ펞
- ������
- �񊈐���

### Step.3
�O�q�̒ʂ�ł��B

�������A����͈ȉ���3��ނ̉摜��ݒ肵�܂��B

- �ʏ펞
- ������
- �񊈐���

```html:MainPage.xaml
<np:TSNPButton Text="custom" TextColor="White"
                Source="TestForms.Resources.red_default.9.png"
                SourcePressed="TestForms.Resources.red_pressed.9.png"
                SourceDisabled="TestForms.Resources.red_disabled.9.png"
                />
```
