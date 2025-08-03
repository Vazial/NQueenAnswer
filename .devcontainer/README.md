# Dev Container for .NET 6.0

このプロジェクトは、.NET 6.0開発環境用のDev Containerを含んでいます。

## 使用方法

1. Visual Studio Codeで「Dev Containers」拡張機能がインストールされていることを確認してください
2. このプロジェクトをVS Codeで開きます
3. コマンドパレット（Ctrl+Shift+P）を開き、「Dev Containers: Reopen in Container」を選択します
4. コンテナのビルドと起動が完了するまで待ちます

## 含まれる機能

- .NET 6.0 SDK
- C# 拡張機能
- Git
- GitHub CLI
- PowerShell

## 自動実行されるコマンド

コンテナ作成後、以下のコマンドが自動実行されます：
- `dotnet restore` - NuGetパッケージの復元

## プロジェクトの実行

コンテナ内で以下のコマンドを実行してプロジェクトをビルド・実行できます：

```bash
# プロジェクトのビルド
dotnet build

# プロジェクトの実行
dotnet run --project NQueenAnswer