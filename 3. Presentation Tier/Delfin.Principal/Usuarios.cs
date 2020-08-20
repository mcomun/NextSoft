// Decompiled with JetBrains decompiler
// Type: NextAdmin.BusinessLogic.Usuarios
// Assembly: NextAdmin.BusinessLogic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AA560238-4268-4FA1-B747-2F76E04DC1E8
// Assembly location: C:\Users\ferar\Documents\My Solutions\NextSoft\LibreriasAdmin\NextAdmin.BusinessLogic.dll

using Infrastructure.Aspect.BusinessEntity;
using Infrastructure.Aspect.Collections;
using Infrastructure.Aspect.ValidationRules;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace NextAdmin.BusinessLogic
{
  [Serializable]
  public class Usuarios : MasterBusinessEntity, INotifyPropertyChanged
  {
    private int m_usua_codigo;
    private string m_usua_codusr;
    private string m_usua_pass;
    private string m_usua_nombres;
    private string m_usua_email;
    private bool m_usua_cambiarpassword;
    private string m_usua_pregunta;
    private string m_usua_respuesta;
    private bool m_usua_estado;
    private bool m_usua_administrador;
    private string m_audi_usrcrea;
    private DateTime m_audi_feccrea;
    private string m_audi_usrmod;
    private DateTime? m_audi_fecmod;
    private ObservableCollection<RolesUsuario> m_listRolesUsuario;
    private ObservableCollection<UsuariosEmpresa> m_listUsuariosEmpresa;
    private ObservableCollection<AccesosUsuario> m_listAccesosUsuario;
    private ObservableCollection<RolesUsuario> m_listRolesUsuarioElim;
    private ObservableCollection<UsuariosEmpresa> m_listUsuariosEmpresaElim;
    private ObservableCollection<AccesosUsuario> m_listAccesosUsuarioElim;
    private bool m_usua_codigoOK;
    private string m_usua_codigoMSGERROR;
    private bool m_usua_codusrOK;
    private string m_usua_codusrMSGERROR;
    private bool m_usua_passOK;
    private string m_usua_passMSGERROR;
    private bool m_usua_nombresOK;
    private string m_usua_nombresMSGERROR;
    private bool m_usua_emailOK;
    private string m_usua_emailMSGERROR;
    private bool m_usua_cambiarpasswordOK;
    private string m_usua_cambiarpasswordMSGERROR;
    private bool m_usua_preguntaOK;
    private string m_usua_preguntaMSGERROR;
    private bool m_usua_respuestaOK;
    private string m_usua_respuestaMSGERROR;
    private bool m_usua_estadoOK;
    private string m_usua_estadoMSGERROR;
    private bool m_audi_usrcreaOK;
    private string m_audi_usrcreaMSGERROR;
    private bool m_audi_feccreaOK;
    private string m_audi_feccreaMSGERROR;
    private bool m_audi_usrmodOK;
    private string m_audi_usrmodMSGERROR;
    private bool m_audi_fecmodOK;
    private string m_audi_fecmodMSGERROR;
    private string m_mensajeError;

    [DataMember]
    public int USUA_Codigo
    {
      get
      {
        return this.m_usua_codigo;
      }
      set
      {
        if (this.m_usua_codigo == value)
          return;
        this.m_usua_codigo = value;
        this.OnPropertyChanged(nameof (USUA_Codigo));
      }
    }

    [DataMember]
    public string USUA_CodUsr
    {
      get
      {
        return this.m_usua_codusr;
      }
      set
      {
        if (!(this.m_usua_codusr != value))
          return;
        this.m_usua_codusr = value;
        this.OnPropertyChanged(nameof (USUA_CodUsr));
      }
    }

    [DataMember]
    public string USUA_Pass
    {
      get
      {
        return this.m_usua_pass;
      }
      set
      {
        if (!(this.m_usua_pass != value))
          return;
        this.m_usua_pass = value;
        this.OnPropertyChanged(nameof (USUA_Pass));
      }
    }

    [DataMember]
    public string USUA_Nombres
    {
      get
      {
        return this.m_usua_nombres;
      }
      set
      {
        if (!(this.m_usua_nombres != value))
          return;
        this.m_usua_nombres = value;
        this.OnPropertyChanged(nameof (USUA_Nombres));
      }
    }

    [DataMember]
    public string USUA_Email
    {
      get
      {
        return this.m_usua_email;
      }
      set
      {
        if (!(this.m_usua_email != value))
          return;
        this.m_usua_email = value;
        this.OnPropertyChanged(nameof (USUA_Email));
      }
    }

    [DataMember]
    public bool USUA_CambiarPassword
    {
      get
      {
        return this.m_usua_cambiarpassword;
      }
      set
      {
        if (this.m_usua_cambiarpassword == value)
          return;
        this.m_usua_cambiarpassword = value;
        this.OnPropertyChanged(nameof (USUA_CambiarPassword));
      }
    }

    [DataMember]
    public string USUA_Pregunta
    {
      get
      {
        return this.m_usua_pregunta;
      }
      set
      {
        if (!(this.m_usua_pregunta != value))
          return;
        this.m_usua_pregunta = value;
        this.OnPropertyChanged(nameof (USUA_Pregunta));
      }
    }

    [DataMember]
    public string USUA_Respuesta
    {
      get
      {
        return this.m_usua_respuesta;
      }
      set
      {
        if (!(this.m_usua_respuesta != value))
          return;
        this.m_usua_respuesta = value;
        this.OnPropertyChanged(nameof (USUA_Respuesta));
      }
    }

    [DataMember]
    public bool USUA_Estado
    {
      get
      {
        return this.m_usua_estado;
      }
      set
      {
        if (this.m_usua_estado == value)
          return;
        this.m_usua_estado = value;
        this.OnPropertyChanged(nameof (USUA_Estado));
      }
    }

    [DataMember]
    public bool USUA_Administrador
    {
      get
      {
        return this.m_usua_administrador;
      }
      set
      {
        if (this.m_usua_administrador == value)
          return;
        this.m_usua_administrador = value;
        this.OnPropertyChanged(nameof (USUA_Administrador));
      }
    }

    [DataMember]
    public string AUDI_UsrCrea
    {
      get
      {
        return this.m_audi_usrcrea;
      }
      set
      {
        if (!(this.m_audi_usrcrea != value))
          return;
        this.m_audi_usrcrea = value;
        this.OnPropertyChanged(nameof (AUDI_UsrCrea));
      }
    }

    [DataMember]
    public DateTime AUDI_FecCrea
    {
      get
      {
        return this.m_audi_feccrea;
      }
      set
      {
        if (!(this.m_audi_feccrea != value))
          return;
        this.m_audi_feccrea = value;
        this.OnPropertyChanged(nameof (AUDI_FecCrea));
      }
    }

    [DataMember]
    public string AUDI_UsrMod
    {
      get
      {
        return this.m_audi_usrmod;
      }
      set
      {
        if (!(this.m_audi_usrmod != value))
          return;
        this.m_audi_usrmod = value;
        this.OnPropertyChanged(nameof (AUDI_UsrMod));
      }
    }

    [DataMember]
    public DateTime? AUDI_FecMod
    {
      get
      {
        return this.m_audi_fecmod;
      }
      set
      {
        DateTime? audiFecmod = this.m_audi_fecmod;
        DateTime? nullable = value;
        if ((audiFecmod.HasValue != nullable.HasValue ? 1 : (!audiFecmod.HasValue ? 0 : (audiFecmod.GetValueOrDefault() != nullable.GetValueOrDefault() ? 1 : 0))) == 0)
          return;
        this.m_audi_fecmod = value;
        this.OnPropertyChanged(nameof (AUDI_FecMod));
      }
    }

    public void CopyTo(ref Usuarios Item)
    {
      try
      {
        if (Item == null)
          Item = new Usuarios();
        Item.USUA_Codigo = this.USUA_Codigo;
        Item.USUA_CodUsr = this.USUA_CodUsr;
        Item.USUA_Pass = this.USUA_Pass;
        Item.USUA_Nombres = this.USUA_Nombres;
        Item.USUA_Email = this.USUA_Email;
        Item.USUA_CambiarPassword = this.USUA_CambiarPassword;
        Item.USUA_Pregunta = this.USUA_Pregunta;
        Item.USUA_Respuesta = this.USUA_Respuesta;
        Item.USUA_Estado = this.USUA_Estado;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    [DataMember]
    public ObservableCollection<RolesUsuario> ListRolesUsuario
    {
      get
      {
        if (this.m_listRolesUsuario == null)
          this.m_listRolesUsuario = new ObservableCollection<RolesUsuario>();
        return this.m_listRolesUsuario;
      }
      set
      {
        this.m_listRolesUsuario = value;
        this.OnPropertyChanged(nameof (ListRolesUsuario));
      }
    }

    [DataMember]
    public ObservableCollection<UsuariosEmpresa> ListUsuariosEmpresa
    {
      get
      {
        if (this.m_listUsuariosEmpresa == null)
          this.m_listUsuariosEmpresa = new ObservableCollection<UsuariosEmpresa>();
        return this.m_listUsuariosEmpresa;
      }
      set
      {
        this.m_listUsuariosEmpresa = value;
        this.OnPropertyChanged(nameof (ListUsuariosEmpresa));
      }
    }

    [DataMember]
    public ObservableCollection<AccesosUsuario> ListAccesosUsuario
    {
      get
      {
        if (this.m_listAccesosUsuario == null)
          this.m_listAccesosUsuario = new ObservableCollection<AccesosUsuario>();
        return this.m_listAccesosUsuario;
      }
      set
      {
        this.m_listAccesosUsuario = value;
        this.OnPropertyChanged(nameof (ListAccesosUsuario));
      }
    }

    [DataMember]
    public ObservableCollection<RolesUsuario> ListRolesUsuarioElim
    {
      get
      {
        if (this.m_listRolesUsuarioElim == null)
          this.m_listRolesUsuarioElim = new ObservableCollection<RolesUsuario>();
        return this.m_listRolesUsuarioElim;
      }
      set
      {
        this.m_listRolesUsuarioElim = value;
        this.OnPropertyChanged(nameof (ListRolesUsuarioElim));
      }
    }

    [DataMember]
    public ObservableCollection<UsuariosEmpresa> ListUsuariosEmpresaElim
    {
      get
      {
        if (this.m_listUsuariosEmpresaElim == null)
          this.m_listUsuariosEmpresaElim = new ObservableCollection<UsuariosEmpresa>();
        return this.m_listUsuariosEmpresaElim;
      }
      set
      {
        this.m_listUsuariosEmpresaElim = value;
        this.OnPropertyChanged(nameof (ListUsuariosEmpresaElim));
      }
    }

    [DataMember]
    public ObservableCollection<AccesosUsuario> ListAccesosUsuarioElim
    {
      get
      {
        if (this.m_listAccesosUsuarioElim == null)
          this.m_listAccesosUsuarioElim = new ObservableCollection<AccesosUsuario>();
        return this.m_listAccesosUsuarioElim;
      }
      set
      {
        this.m_listAccesosUsuario = value;
        this.OnPropertyChanged(nameof (ListAccesosUsuarioElim));
      }
    }

    public void CambioListas()
    {
      this.OnPropertyChanged("ListRolesUsuario");
      this.OnPropertyChanged("ListUsuariosEmpresa");
      this.OnPropertyChanged("ListAccesosUsuario");
    }

    public bool ValidarMail()
    {
      bool flag = true;
      this.m_mensajeError = "";
      if (!string.IsNullOrEmpty(this.m_usua_email) && !string.IsNullOrWhiteSpace(this.m_usua_email) && !ValidarMail.ValidarE_Mail(this.m_usua_email))
      {
        flag = false;
        Usuarios usuarios = this;
        usuarios.m_mensajeError = usuarios.m_mensajeError + "* Debe ingresar un E-mail correcto" + Environment.NewLine;
      }
      return flag;
    }

    public bool AddRolesUsuario(Roles x_newRol)
    {
      try
      {
        if (this.ListRolesUsuario.Where<RolesUsuario>((Func<RolesUsuario, bool>) (rolesUs => rolesUs.ROLE_Codigo == x_newRol.ROLE_Codigo)).Count<RolesUsuario>() != 0)
          return false;
        RolesUsuario rolesUsuario = new RolesUsuario();
        rolesUsuario.ROLE_Codigo = x_newRol.ROLE_Codigo;
        rolesUsuario.ROLE_Desc = x_newRol.ROLE_Desc;
        rolesUsuario.USUA_Codigo = this.USUA_Codigo;
        rolesUsuario.Instance = InstanceEntity.Added;
        this.ListRolesUsuario.Add(rolesUsuario);
        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void AddRolesUsuario(ObservableCollection<Roles> x_listRoles)
    {
      try
      {
        foreach (Roles xListRole in (Collection<Roles>) x_listRoles)
          this.AddRolesUsuario(xListRole);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public bool AddUsuariosEmpresa(Empresas x_newEmpresa)
    {
      try
      {
        if (this.ListUsuariosEmpresa.Where<UsuariosEmpresa>((Func<UsuariosEmpresa, bool>) (emp => emp.EMPR_Codigo == x_newEmpresa.EMPR_Codigo)).Count<UsuariosEmpresa>() != 0)
          return false;
        UsuariosEmpresa usuariosEmpresa = new UsuariosEmpresa();
        usuariosEmpresa.EMPR_Codigo = x_newEmpresa.EMPR_Codigo;
        usuariosEmpresa.EMPR_Desc = x_newEmpresa.EMPR_Desc;
        usuariosEmpresa.USUA_Codigo = this.USUA_Codigo;
        usuariosEmpresa.Instance = InstanceEntity.Added;
        this.ListUsuariosEmpresa.Add(usuariosEmpresa);
        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void AddUsuariosEmpresa(ObservableCollection<Empresas> x_listEmpresas)
    {
      try
      {
        foreach (Empresas xListEmpresa in (Collection<Empresas>) x_listEmpresas)
          this.AddUsuariosEmpresa(xListEmpresa);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public bool AddAccesosUsuario(Aplicaciones x_newAplicacion, int USUE_Codigo)
    {
      try
      {
        if (this.ListAccesosUsuario.Where<AccesosUsuario>((Func<AccesosUsuario, bool>) (accesos => accesos.APLI_Codigo == x_newAplicacion.APLI_Codigo)).Count<AccesosUsuario>() != 0)
          return false;
        AccesosUsuario accesosUsuario = new AccesosUsuario();
        accesosUsuario.APLI_Codigo = x_newAplicacion.APLI_Codigo;
        accesosUsuario.APLI_Desc = x_newAplicacion.APLI_Desc;
        accesosUsuario.USUE_Codigo = USUE_Codigo;
        accesosUsuario.Instance = InstanceEntity.Added;
        this.ListAccesosUsuario.Add(accesosUsuario);
        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void AddAccesosUsuario(ObservableCollection<Aplicaciones> x_listAplicaciones, int USUE_Codigo)
    {
      try
      {
        foreach (Aplicaciones xListAplicacione in (Collection<Aplicaciones>) x_listAplicaciones)
          this.AddAccesosUsuario(xListAplicacione, USUE_Codigo);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public bool DeleteRolesUsuario(int ROLE_Codigo)
    {
      try
      {
        RolesUsuario rolesUsuario = this.ListRolesUsuario.Where<RolesUsuario>((Func<RolesUsuario, bool>) (roles => roles.ROLE_Codigo == ROLE_Codigo)).FirstOrDefault<RolesUsuario>();
        if (rolesUsuario == null)
          return false;
        if (rolesUsuario.Instance != InstanceEntity.Added)
        {
          rolesUsuario.Instance = InstanceEntity.Deleted;
          this.ListRolesUsuarioElim.Add(rolesUsuario);
          this.ListRolesUsuario.Remove(rolesUsuario);
          return true;
        }
        this.ListRolesUsuario.Remove(rolesUsuario);
        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void DeleteRolesUsuario(ObservableCollection<Roles> x_listRoles)
    {
      try
      {
        foreach (Roles xListRole in (Collection<Roles>) x_listRoles)
          this.DeleteRolesUsuario(xListRole.ROLE_Codigo);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void DeleteAllRolesUsuario()
    {
      try
      {
        foreach (RolesUsuario rolesUsuario in (Collection<RolesUsuario>) this.ListRolesUsuario)
        {
          if (rolesUsuario.Instance != InstanceEntity.Added)
          {
            rolesUsuario.Instance = InstanceEntity.Deleted;
            this.ListRolesUsuarioElim.Add(rolesUsuario);
          }
        }
        this.ListRolesUsuario.Clear();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public bool DeleteUsuariosEmpresa(int EMPR_Codigo)
    {
      try
      {
        UsuariosEmpresa usuariosEmpresa = this.ListUsuariosEmpresa.Where<UsuariosEmpresa>((Func<UsuariosEmpresa, bool>) (empresas => empresas.EMPR_Codigo == EMPR_Codigo)).FirstOrDefault<UsuariosEmpresa>();
        if (usuariosEmpresa == null)
          return false;
        if (usuariosEmpresa.Instance != InstanceEntity.Added)
        {
          usuariosEmpresa.Instance = InstanceEntity.Deleted;
          this.ListUsuariosEmpresaElim.Add(usuariosEmpresa);
          this.ListUsuariosEmpresa.Remove(usuariosEmpresa);
          return true;
        }
        this.ListUsuariosEmpresa.Remove(usuariosEmpresa);
        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void DeleteUsuariosEmpresa(ObservableCollection<Empresas> x_listEmpresas)
    {
      try
      {
        foreach (Empresas xListEmpresa in (Collection<Empresas>) x_listEmpresas)
          this.DeleteUsuariosEmpresa(xListEmpresa.EMPR_Codigo);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void DeleteAllUsuariosEmpresa()
    {
      try
      {
        foreach (UsuariosEmpresa usuariosEmpresa in (Collection<UsuariosEmpresa>) this.ListUsuariosEmpresa)
        {
          if (usuariosEmpresa.Instance != InstanceEntity.Added)
          {
            usuariosEmpresa.Instance = InstanceEntity.Deleted;
            this.ListUsuariosEmpresaElim.Add(usuariosEmpresa);
          }
        }
        this.ListUsuariosEmpresa.Clear();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public bool DeleteAccesosUsuario(int APLI_Codigo)
    {
      try
      {
        AccesosUsuario accesosUsuario = this.ListAccesosUsuario.Where<AccesosUsuario>((Func<AccesosUsuario, bool>) (acceso => acceso.APLI_Codigo == APLI_Codigo)).FirstOrDefault<AccesosUsuario>();
        if (accesosUsuario == null)
          return false;
        if (accesosUsuario.Instance != InstanceEntity.Added)
        {
          accesosUsuario.Instance = InstanceEntity.Deleted;
          this.ListAccesosUsuarioElim.Add(accesosUsuario);
          this.ListAccesosUsuario.Remove(accesosUsuario);
          return true;
        }
        this.ListAccesosUsuario.Remove(accesosUsuario);
        return true;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void DeleteAccesosUsuario(ObservableCollection<Aplicaciones> x_listAplicaciones)
    {
      try
      {
        foreach (Aplicaciones xListAplicacione in (Collection<Aplicaciones>) x_listAplicaciones)
          this.DeleteAccesosUsuario(xListAplicacione.APLI_Codigo);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public void DeleteAllAccesosUsuarios(int USUE_Codigo)
    {
      try
      {
        foreach (AccesosUsuario observable in (Collection<AccesosUsuario>) this.ListAccesosUsuario.Where<AccesosUsuario>((Func<AccesosUsuario, bool>) (acceso => acceso.USUE_Codigo == USUE_Codigo)).ToObservableCollection<AccesosUsuario>())
        {
          if (observable.Instance != InstanceEntity.Added)
          {
            observable.Instance = InstanceEntity.Deleted;
            this.ListAccesosUsuarioElim.Add(observable);
            this.ListAccesosUsuario.Remove(observable);
          }
          else
            this.ListAccesosUsuario.Remove(observable);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    [DataMember]
    public bool USUA_CodigoOK
    {
      get
      {
        return this.m_usua_codigoOK;
      }
      set
      {
        if (this.m_usua_codigoOK == value)
          return;
        this.m_usua_codigoOK = value;
        this.OnPropertyChanged(nameof (USUA_CodigoOK));
      }
    }

    [DataMember]
    public string USUA_CodigoMSGERROR
    {
      get
      {
        return this.m_usua_codigoMSGERROR;
      }
      set
      {
        if (!(this.m_usua_codigoMSGERROR != value))
          return;
        this.m_usua_codigoMSGERROR = value;
        this.OnPropertyChanged(nameof (USUA_CodigoMSGERROR));
      }
    }

    [DataMember]
    public bool USUA_CodUsrOK
    {
      get
      {
        return this.m_usua_codusrOK;
      }
      set
      {
        if (this.m_usua_codusrOK == value)
          return;
        this.m_usua_codusrOK = value;
        this.OnPropertyChanged(nameof (USUA_CodUsrOK));
      }
    }

    [DataMember]
    public string USUA_CodUsrMSGERROR
    {
      get
      {
        return this.m_usua_codusrMSGERROR;
      }
      set
      {
        if (!(this.m_usua_codusrMSGERROR != value))
          return;
        this.m_usua_codusrMSGERROR = value;
        this.OnPropertyChanged(nameof (USUA_CodUsrMSGERROR));
      }
    }

    [DataMember]
    public bool USUA_PassOK
    {
      get
      {
        return this.m_usua_passOK;
      }
      set
      {
        if (this.m_usua_passOK == value)
          return;
        this.m_usua_passOK = value;
        this.OnPropertyChanged(nameof (USUA_PassOK));
      }
    }

    [DataMember]
    public string USUA_PassMSGERROR
    {
      get
      {
        return this.m_usua_passMSGERROR;
      }
      set
      {
        if (!(this.m_usua_passMSGERROR != value))
          return;
        this.m_usua_passMSGERROR = value;
        this.OnPropertyChanged(nameof (USUA_PassMSGERROR));
      }
    }

    [DataMember]
    public bool USUA_NombresOK
    {
      get
      {
        return this.m_usua_nombresOK;
      }
      set
      {
        if (this.m_usua_nombresOK == value)
          return;
        this.m_usua_nombresOK = value;
        this.OnPropertyChanged(nameof (USUA_NombresOK));
      }
    }

    [DataMember]
    public string USUA_NombresMSGERROR
    {
      get
      {
        return this.m_usua_nombresMSGERROR;
      }
      set
      {
        if (!(this.m_usua_nombresMSGERROR != value))
          return;
        this.m_usua_nombresMSGERROR = value;
        this.OnPropertyChanged(nameof (USUA_NombresMSGERROR));
      }
    }

    [DataMember]
    public bool USUA_EmailOK
    {
      get
      {
        return this.m_usua_emailOK;
      }
      set
      {
        if (this.m_usua_emailOK == value)
          return;
        this.m_usua_emailOK = value;
        this.OnPropertyChanged(nameof (USUA_EmailOK));
      }
    }

    [DataMember]
    public string USUA_EmailMSGERROR
    {
      get
      {
        return this.m_usua_emailMSGERROR;
      }
      set
      {
        if (!(this.m_usua_emailMSGERROR != value))
          return;
        this.m_usua_emailMSGERROR = value;
        this.OnPropertyChanged(nameof (USUA_EmailMSGERROR));
      }
    }

    [DataMember]
    public bool USUA_CambiarPasswordOK
    {
      get
      {
        return this.m_usua_cambiarpasswordOK;
      }
      set
      {
        if (this.m_usua_cambiarpasswordOK == value)
          return;
        this.m_usua_cambiarpasswordOK = value;
        this.OnPropertyChanged(nameof (USUA_CambiarPasswordOK));
      }
    }

    [DataMember]
    public string USUA_CambiarPasswordMSGERROR
    {
      get
      {
        return this.m_usua_cambiarpasswordMSGERROR;
      }
      set
      {
        if (!(this.m_usua_cambiarpasswordMSGERROR != value))
          return;
        this.m_usua_cambiarpasswordMSGERROR = value;
        this.OnPropertyChanged(nameof (USUA_CambiarPasswordMSGERROR));
      }
    }

    [DataMember]
    public bool USUA_PreguntaOK
    {
      get
      {
        return this.m_usua_preguntaOK;
      }
      set
      {
        if (this.m_usua_preguntaOK == value)
          return;
        this.m_usua_preguntaOK = value;
        this.OnPropertyChanged(nameof (USUA_PreguntaOK));
      }
    }

    [DataMember]
    public string USUA_PreguntaMSGERROR
    {
      get
      {
        return this.m_usua_preguntaMSGERROR;
      }
      set
      {
        if (!(this.m_usua_preguntaMSGERROR != value))
          return;
        this.m_usua_preguntaMSGERROR = value;
        this.OnPropertyChanged(nameof (USUA_PreguntaMSGERROR));
      }
    }

    [DataMember]
    public bool USUA_RespuestaOK
    {
      get
      {
        return this.m_usua_respuestaOK;
      }
      set
      {
        if (this.m_usua_respuestaOK == value)
          return;
        this.m_usua_respuestaOK = value;
        this.OnPropertyChanged(nameof (USUA_RespuestaOK));
      }
    }

    [DataMember]
    public string USUA_RespuestaMSGERROR
    {
      get
      {
        return this.m_usua_respuestaMSGERROR;
      }
      set
      {
        if (!(this.m_usua_respuestaMSGERROR != value))
          return;
        this.m_usua_respuestaMSGERROR = value;
        this.OnPropertyChanged(nameof (USUA_RespuestaMSGERROR));
      }
    }

    [DataMember]
    public bool USUA_EstadoOK
    {
      get
      {
        return this.m_usua_estadoOK;
      }
      set
      {
        if (this.m_usua_estadoOK == value)
          return;
        this.m_usua_estadoOK = value;
        this.OnPropertyChanged(nameof (USUA_EstadoOK));
      }
    }

    [DataMember]
    public string USUA_EstadoMSGERROR
    {
      get
      {
        return this.m_usua_estadoMSGERROR;
      }
      set
      {
        if (!(this.m_usua_estadoMSGERROR != value))
          return;
        this.m_usua_estadoMSGERROR = value;
        this.OnPropertyChanged(nameof (USUA_EstadoMSGERROR));
      }
    }

    [DataMember]
    public string MensajeError
    {
      get
      {
        return this.m_mensajeError;
      }
    }

    public bool Validar()
    {
      try
      {
        bool flag = true;
        this.m_mensajeError = "";
        this.USUA_CodigoOK = true;
        this.USUA_CodigoMSGERROR = "";
        this.USUA_PassOK = true;
        this.USUA_PassMSGERROR = "";
        this.USUA_NombresOK = true;
        this.USUA_NombresMSGERROR = "";
        if (string.IsNullOrEmpty(this.USUA_Nombres))
        {
          flag = false;
          this.USUA_NombresOK = false;
          this.USUA_NombresMSGERROR = string.Format("Debe ingresar el {0} de la {1}.", (object) "USUA_Nombres", (object) nameof (Usuarios));
          Usuarios usuarios = this;
          usuarios.m_mensajeError = usuarios.m_mensajeError + "* Debe ingresar el campo USUA_Nombres" + Environment.NewLine;
        }
        this.USUA_CambiarPasswordOK = true;
        this.USUA_CambiarPasswordMSGERROR = "";
        this.USUA_PreguntaOK = true;
        this.USUA_PreguntaMSGERROR = "";
        this.USUA_RespuestaOK = true;
        this.USUA_RespuestaMSGERROR = "";
        this.USUA_EstadoOK = true;
        this.USUA_EstadoMSGERROR = "";
        int num = this.USUA_Estado ? 1 : 0;
        this.OnPropertyChanged("MensajeError");
        return flag;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
