package projekttsm.tanksonline;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Toast;
import android.widget.Button;
import android.widget.EditText;
import android.content.Intent;


public class LoginActivity extends AppCompatActivity {

    Button b1, b2;
    EditText ed1, ed2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.content_login);

        b1 = (Button) findViewById(R.id.LoginButton);
        b2 = (Button) findViewById(R.id.registerButton);
        ed1 = (EditText) findViewById(R.id.nameText);
        ed2 = (EditText) findViewById(R.id.passwordText);


        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (ed1.getText().toString().equals("admin") &&
                        ed2.getText().toString().equals("admin")) {
                    Toast.makeText(getApplicationContext(),
                            "Redirecting...", Toast.LENGTH_SHORT).show();
                    Intent intent = new Intent(LoginActivity.this, MainActivity.class);
                    startActivity(intent);
                } else {
                    Toast.makeText(getApplicationContext(),
                            "Something go wrong...", Toast.LENGTH_SHORT).show();
                }
            }
        });

        b2.setOnClickListener(new View.OnClickListener(){
            @Override
                    public  void  onClick(View v) {
                Intent intent = new Intent(LoginActivity.this, RegisterActivity.class);
                startActivity(intent);
            }
        });
    }
}



