using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace HomeworkOne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer("mywavfile.wav");
            // player.Play();
            label4.Text = playerLives.ToString();
            label6.Text = score.ToString();
            createEnemy();
        }

        float currentFrame = 0;
        Texture main = new Texture();
        List<Enemy> enemyList = new List<Enemy>();
        int playerLives = 10;
        int score = 0;


        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
            gl.Enable(OpenGL.GL_TEXTURE_2D);


            if (playerLives != 0)
            {
                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.LoadIdentity();
                gl.Translate(0.0f, 0.0f, -20.0f);
                main.Create(gl, "..\\..\\main.png");

                gl.PushMatrix();
                gl.Begin(OpenGL.GL_QUADS);
                gl.TexCoord(1, 1); gl.Vertex(-1, -1);
                gl.TexCoord(0, 1); gl.Vertex(1, -1);
                gl.TexCoord(0, 0); gl.Vertex(1, 1);
                gl.TexCoord(1, 0); gl.Vertex(-1, 1);

                gl.End();
                gl.PopMatrix();
                currentFrame = currentFrame + 1;
                if (currentFrame % 28 == 0)
                {
                    createEnemy();
                    currentFrame = 0;
                }
                moveEnemy();

                if (enemyList != null)
                {
                    for (int i = 0; i < enemyList.Count; i++)
                    {
                        enemyList[i].drawEnemy(gl);
                    }
                }
                gl.Flush();
            }
            else
            {
                label2.Text = "Game over";
            }
        }


        private void createEnemy()
        {
            Random rnd = new Random();
            float randPositionX = rnd.Next(-14, 14);
            float randPositionY = rnd.Next(0, 2) == 1 ? rnd.Next(-6, -4) : rnd.Next(6, 8);
            Enemy newEnemy;
            int randomEnemy = rnd.Next(1, 5);
            newEnemy = new Enemy(randPositionX, randPositionY, 0.05*randomEnemy, randomEnemy);

            enemyList.Add(newEnemy);


        }

        private Boolean isEnemyAtPlayer(double xPosition, double yPosition)
        {
            return Math.Sqrt(Math.Pow(xPosition, 2) + Math.Pow(yPosition,2)) <= 1;
        }

        private void moveEnemy()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
           
                if (isEnemyAtPlayer(enemyList[i].positionX, enemyList[i].positionY))
                {
                    enemyList.RemoveAt(i);
                    playerLives = playerLives - 1;
                    label4.Text = playerLives.ToString();
                }
            }
                for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].moveEnemy();
            }
        }

        private void openGLControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char keyPressed = e.KeyChar;
            switch(keyPressed)
            {
                case '1':
                    destroyEnemies(1);
                    break;
                case '2':
                    destroyEnemies(2);
                    break;
                case '3':
                    destroyEnemies(3);
                    break;
                case '4':
                    destroyEnemies(4);
                    break;
            }
        }

        private void destroyEnemies(int enemyType)
        {
            for (int i = 0; i < enemyList.Count; i++)
            {

                if (enemyType.Equals(enemyList[i].enemyType))
                {
                    enemyList.RemoveAt(i);
                    score = score + 1;
                    label6.Text = score.ToString();
                }
            }
        }

    }
}
