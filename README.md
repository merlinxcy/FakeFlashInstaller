# FakeFlashInstaller
fake flash installer write in  c#

## 原理
1.	跳转flash更新页面提示连接失败无法更新
2.	Flash进程常驻后台开始使用AES解密Stage下载地址，前往Stage下载地址http://XXX/favicon.bmp 下载图片并解密隐写的二进制数据。
3.	通过loadAssembly加载二进制进行C2上线


## 用法
绘制flash界面：

 ![image](https://user-images.githubusercontent.com/18378246/135007520-e850c1da-9044-48d1-a555-99cc46bf9e52.png)



将二阶段木马隐写入图片文件中

 ![image](https://user-images.githubusercontent.com/18378246/135007525-3a05e5a9-1a61-458e-82fc-5fd08354d32e.png)


生成加密的图片URL地址


 ![image](https://user-images.githubusercontent.com/18378246/135007535-a575b105-7bea-46fa-b3cb-80a724eab48f.png)


替换URL 配置


 ![image](https://user-images.githubusercontent.com/18378246/135007544-6aadcd66-c23a-4f0c-9ef9-adcc30cd6ebb.png)




编译64位的Release进行投递
