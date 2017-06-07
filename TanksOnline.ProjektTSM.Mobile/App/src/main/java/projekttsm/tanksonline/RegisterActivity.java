package projekttsm.tanksonline;

import android.app.AlertDialog;
import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toolbar;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import com.android.volley.toolbox.Volley;
import org.json.JSONException;
import org.json.JSONObject;


import org.json.JSONException;
import org.json.JSONObject;

public class RegisterActivity extends AppCompatActivity {

    Button b1, b2;
    EditText etName, etPass, etEmail;
    String url = "http://localhost:21021//";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.content_register);


        b1 = (Button) findViewById(R.id.registerButton);
        b2 = (Button) findViewById(R.id.returnButton);
        etName = (EditText) findViewById(R.id.nameEditText);
        etPass = (EditText) findViewById(R.id.passEditText);
        etEmail = (EditText) findViewById(R.id.emailEditText);

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                final String email = etEmail.getText().toString();
                final String name = etName.getText().toString();
                final String pass = etPass.getText().toString();
                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        AlertDialog.Builder builder = new AlertDialog.Builder(RegisterActivity.this);
                        builder.setMessage("Udało Ci się stworzyć konto! Gratulacje, możesz się teraz zalogować.")
                                .create()
                                .show();
                                Intent intent = new Intent(RegisterActivity.this, LoginActivity.class);
                                startActivity(intent);
                    }
                };
                RegisterRequest registerRequest = new RegisterRequest(name, email, pass, responseListener);
                RequestQueue queue = Volley.newRequestQueue(RegisterActivity.this);
                queue.add(registerRequest);
            }
        });

        b2.setOnClickListener(new View.OnClickListener(){
            @Override
            public  void  onClick(View v) {
                Intent intent = new Intent(RegisterActivity.this, LoginActivity.class);
                startActivity(intent);
            }
        });

    }

}
