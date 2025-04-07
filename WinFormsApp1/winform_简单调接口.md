### 控件

视图->工具箱



### 点击事件

属性中，点击黄色闪电会自动到操作，填了之后自动生成方法

![image-20250324103743293](https://cdn.jsdelivr.net/gh/humoyun1798/image/image/imagessimage-20250324103743293.png)

### designer文本多行、滚动条

```c#
 textBox2.Location = new System.Drawing.Point(19, 86);
 textBox2.Multiline = true;
 textBox2.Name = "textBox2";
 textBox2.ScrollBars = ScrollBars.Vertical;
 textBox2.Size = new System.Drawing.Size(339, 237);
 textBox2.TabIndex = 4;
 textBox2.TextChanged += textBox2_TextChanged_1;
```





### 关闭事件

![image-20250407114046122](https://cdn.jsdelivr.net/gh/humoyun1798/image/image/imagessimage-20250407114046122.png)

### 窗口隐藏显示、程序结束

form.Show()
form.Hide()

Application.Exit(); 程序结束退出 //多页面的话不加这个可能依然在后台运行，只是看不见页面了

