# BDVHDLtoNetlist
**BDVHDLtoNetlist**は，BDVHDL(独自に定義したVHDLのサブセット)で記述されたネットリストをKiCad(Pcbnew)形式のネットリストに変換するツールです．
BDVHDLはVHDLの文法に一定の制限を加えたものですが，表現力は正規のVHDLと変わらず，一定の制約を守ることでQuartus Primeの回路図エディタから直接生成することができます．

BDVHDLtoNetlist is a software to generate KiCAD Netlist from BDVHDL(VHDL subset) code.
BDVHDL is as expressive as standard VHDL and can be generated automatically by Quartus Schematic Editor within certain constraints.

## **BDVHDLtoNetlist**が利用できる場面
**BDVHDLtoNetlist**は，汎用ロジックICとメモリICのみからCPUを作る自由研究のために実装したものです．

VHDLでディジタル回路を記述しModelSim等を利用してシミュレーションを行った後で，回路の正しさの保証を失わないままで基板設計を行うためには，VHDLの記述から自動的にネットリストを得る必要がありますが，**BDVHDLtoNetlist**を利用することでこれが実現できます．

複雑なディジタル回路をPCB上に作成するような場面(もっとも現代では大学生の自由研究くらいしかないかもしれないが)では，有効なツールになると思われます．

## **BDVHDLtoNetlist**を使った作業フローの例
1. BDVHDLで回路設計を行う
   - BDVHDLを直接記述する
   - Quartus Primeの回路図エディタを利用する(後述)
2. 設計した回路に対してModelSimなどを用いてシミュレーションを行う
3. BDVHDLで基板上に配置するチップの定義を行う
   - 論理ゲートやエンティティと，基板上に配置するチップを対応付ける
4. **BDVHDLtoNetlist**を用いてネットリストを得る
5. ネットリストをPcbnewにインポートし，基板設計を行う

## Quartus Primeの回路図エディタからBDVHDLの記述を得る方法
BDVHDLは基本的にはネットリストと同じ情報しか持たず，例外的に論理ゲートを記述することができます．

回路中の全ての順序回路と，複雑な組み合わせ回路は別のエンティティとしてVHDLで記述しておき，BDVHDLにコンポネントとして組み込むという方法をとります．

より具体的には，回路図エディタで使用できる回路の要素は以下のものに限られます．
- 別のエンティティとしてVHDLで記述し，さらに別のBDVHDLでチップと対応付けたコンポネント
- 回路図エディタの`primitives/logic`以下に存在する基本的な論理ゲート

したがって，フリップフロップやマルチプレクサ，3ステートバッファなどの複雑な回路要素を利用する場合は，これを別のエンティティとして記述し，さらに別にBDVHDLでチップと対応付けた上で，コンポネントとして回路に追加します．

なお，回路エディタで使用した論理ゲートも，別にBDVHDLを記述してチップと対応付ける必要があります．
例えば，回路図中で2入力NANDゲートを利用する場合，`library/ic7400.vhd`のようにチップと対応付けます．

## 利用方法
`BDVHDLtoNetlist.exe BDVHDLファイル ライブラリのディレクトリ 出力先`

- `BDVHDLファイル`: 回路をBDVHDLで記述したもの
- `ライブラリのディレクトリ`: チップの定義を含んだディレクトリ(リポジトリ中のlibraryディレクトリなどを指定する)
- `出力先`: ネットリストの出力先

## その他
需要があれば更に詳しい説明を書きます...
